using UnityEngine;

public class SniperTowerBehavoir : ShootingTowerBehavoir
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackRange;

    [SerializeField] private Transform _shotPoint;

    [SerializeField] private TargetBullet _prefab;
    [SerializeField] private int _countBullets = 3;

    private ObjectPool<TargetBullet> _bulletPool;

    private float _lastAttackTime = 0;

    public void SetStats(float damage, float attackSpeed, float attackRange)
    {
        _damage = damage;
        _attackSpeed = attackSpeed;
        _attackRange = attackRange;
    }

    private void Awake()
    {
        _bulletPool = new ObjectPool<TargetBullet>(_prefab, _countBullets, transform, true);
    }

    private void Update()
    {
        if (_target == null)
        {
            FindTarget();
        }
        else
        {
            if (Time.time - _lastAttackTime >= 1 / _attackSpeed)
            {
                if (IsEnemyCorrect(_target))
                {
                    AttackEnemy(_target);
                    _lastAttackTime = Time.time;
                }
                else
                {
                    _target = null;
                }
            }
        }
    }

    private void FindTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRange);

        _target = FindNearestEnemy(hitColliders);
    }

    private GameObject FindNearestEnemy(Collider[] colliders)
    {
        GameObject nearestEnemy = null;
        float nearestDistance = float.MaxValue;

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.activeSelf && collider.TryGetComponent(out EnemyHealth enemy))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);

                if (distance <= nearestDistance)
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
        var targetBullet = _bulletPool.GetFreeElement();

        targetBullet.transform.position = _shotPoint.position;
        targetBullet.Init(enemy, _damage);
    }

    private bool IsEnemyCorrect(GameObject enemy)
    {
        float distance = Vector3.Distance(transform.position, enemy.transform.position);

        if (distance > _attackRange)
        {
            return false;
        }

        if (enemy.activeSelf == false)
        {
            return false;
        }

        return true;
    }
}
