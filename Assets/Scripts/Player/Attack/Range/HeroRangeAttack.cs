using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class HeroRangeAttack : MonoBehaviour
{
    private Transform _attackPoint;
    private PlayerStats _player;
    private ObjectPool<TargetBullet> _bulletPool;

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
                if (IsEnemyCorrect())
                {
                    AttackEnemy(_currentEnemy);
                    _lastAttackTime = Time.time;
                }
                else
                {
                    _currentEnemy = null;
                }                
            }
        }
    }

    public void SetAttackPoint(Transform point)
    {
        _attackPoint = point;
    }

    public void SetBulletPool(ObjectPool<TargetBullet> pool)
    {
        _bulletPool = pool;
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
        if (_bulletPool == null) return;

        var targetBullet = _bulletPool.GetFreeElement();

        targetBullet.gameObject.SetActive(true);
        targetBullet.transform.position = _attackPoint.position;
        targetBullet.Init(enemy, _player.Damage);
    }

    private bool IsEnemyCorrect()
    {
        float distance = Vector3.Distance(transform.position, _currentEnemy.transform.position);

        if (distance > _player.AttackRange || _currentEnemy.activeSelf == false)
        {
            _currentEnemy = null;
            return false;
        }

        EnemyHealth enemyHealth = _currentEnemy.GetComponent<EnemyHealth>();

        if(enemyHealth.IsAlive == false)
        {
            _currentEnemy = null;
            return false;
        }

        return true;
    }
}