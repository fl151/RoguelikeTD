using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireTowerBehavoir : ShootingTowerBehavoir
{
    private const float _explosionRadius = 1;

    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _maxY;

    [SerializeField] private Transform _shotPoint;

    [SerializeField] private ExplosionBullet _bulletPrefab;
    [SerializeField] private int _countBullets = 3;

    private ObjectPool<ExplosionBullet> _bulletPool;

    private float _lastAttackTime = 0;

    public void SetStats(float damage, float attackSpeed, float attackRange)
    {
        _damage = damage;
        _attackSpeed = attackSpeed;
        _attackRange = attackRange;
    }

    private void Awake()
    {
        _bulletPool = new ObjectPool<ExplosionBullet>(_bulletPrefab, _countBullets, transform, true);
    }

    private void Update()
    {
        if (Time.time - _lastAttackTime >= 1 / _attackSpeed)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRange);

            var enemyes = from hit in hitColliders
                          where hit.TryGetComponent(out EnemyHealth enemy)
                          select hit.gameObject;

            if (enemyes.Count() != 0)
            {
                _target = GetRandomEnemy(enemyes.ToList());

                AttackPoint(_target.transform.position);
                _lastAttackTime = Time.time;
            }
        }
    }

    private GameObject GetRandomEnemy(List<GameObject> enemyes)
    {
        GameObject enemy = enemyes[Random.Range(0, enemyes.Count())];

        return enemy;
    }

    private void AttackPoint(Vector3 point)
    {
        var explosionBullet = _bulletPool.GetFreeElement();

        explosionBullet.transform.position = _shotPoint.position;
        explosionBullet.SetStats(_damage, _explosionRadius, _maxY);
        explosionBullet.SetTargetPoint(point);
    }
}
