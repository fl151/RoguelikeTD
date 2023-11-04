using UnityEngine;
using System.Linq;

public class IceTowerBehavoir : ShootingTowerBehavoir
{
    private const float _attackRange = 7.5f;

    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _slowCoefficient;

    [SerializeField] private Transform _shotPoint;

    [SerializeField] private IceBullet _bulletPrefab;
    [SerializeField] private int _countBullets = 3;

    private ObjectPool<IceBullet> _bulletPool;

    private float _lastAttackTime = 0;

    public void SetStats(float damage, float attackSpeed, float slowCoefficient)
    {
        _damage = damage;
        _attackSpeed = attackSpeed;
        _slowCoefficient = slowCoefficient;
    }

    private void Awake()
    {
        _bulletPool = new ObjectPool<IceBullet>(_bulletPrefab, _countBullets, transform, true);
    }

    private void Update()
    {
        if (Time.time - _lastAttackTime >= 1 / _attackSpeed)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRange);

            var enemyes = from hit in hitColliders
                          where hit.TryGetComponent(out EnemyHealth enemy)
                          select hit.gameObject;

            _target = GetRandomEnemy(enemyes.ToArray());

            if (_target != null)
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

    private GameObject GetRandomEnemy(GameObject[] enemyes)
    {
        if (enemyes.Length == 0) return null;

        var enemy = enemyes[Random.Range(0, enemyes.Length)];

        return enemy;
    }

    private void AttackEnemy(GameObject enemy)
    {
        var iceBullet = _bulletPool.GetFreeElement();

        iceBullet.transform.position = _shotPoint.position;
        iceBullet.Init(enemy, _damage);
        iceBullet.SetSlowCoefficient(_slowCoefficient);
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
