using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(BulletPool))]
public class HeroRangeAttack : MonoBehaviour
{
    private Transform _attackPoint;
    private PlayerStats _player;
    private BulletPool _bulletPool;

    private float _lastAttackTime = 0f;

    private GameObject _currentEnemy;

    private void Awake()
    {
        _player = GetComponent<PlayerStats>();
        _bulletPool = GetComponent<BulletPool>();
    }

    private void Update()
    {
        if (_currentEnemy == null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _player.AttackRange);

            _currentEnemy = FindNearestEnemy(hitColliders);            
        }
        else
        {
            if (Time.time - _lastAttackTime >= 1 / _player.AttackSpeed)
            {
                AttackEnemy(_currentEnemy);
                _lastAttackTime = Time.time;
            }
        }
    }

    public void SetAttackPoint(Transform point)
    {
        _attackPoint = point;
    }

    private GameObject FindNearestEnemy(Collider[] colliders)
    {
        GameObject nearestEnemy = null;
        float nearestDistance = float.MaxValue;

        foreach (Collider collider in colliders)
        {
            EnemyHealth enemy = collider.GetComponent<EnemyHealth>();

            if (enemy != null && collider.gameObject.activeSelf)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);

                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = collider.gameObject;
                }
            }
        }

        return nearestEnemy;
    }

    private void AttackEnemy(GameObject enemy)
    {
        if (_bulletPool.TryGetBullet(out Bullet bullet))
        {
            var targetBullet = bullet as TargetBullet;

            targetBullet.gameObject.SetActive(true);
            targetBullet.transform.position = _attackPoint.position;
            targetBullet.SetTarget(enemy);
            targetBullet.SetDamage(_player.Damage);
        }
    }
}