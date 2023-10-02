using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class HeroRangeAttack : MonoBehaviour
{
    [SerializeField] private TargetBullet _bulletPrefab;

    private Transform _attackPoint;
    private PlayerStats _player;

    private float _lastAttackTime = 0f;

    private GameObject _currentEnemy;

    private void Awake()
    {
        _player = GetComponent<PlayerStats>();
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
        TargetBullet bullet = Instantiate(_bulletPrefab, _attackPoint.position, Quaternion.identity);
        bullet.SetTarget(enemy);
        bullet.SetDamage(_player.Damage);
    }
}