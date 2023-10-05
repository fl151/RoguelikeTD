using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireTowerBehavoir : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _maxY;

    [SerializeField] private Transform _shotPoint;

    private BulletPool _bulletPool;

    private float _lastAttackTime = 0;

    public void SetStats(float damage, float attackSpeed, float attackRange, float explosionRadius)
    {
        _damage = damage;
        _attackSpeed = attackSpeed;
        _attackRange = attackRange;
        _explosionRadius = explosionRadius;
    }

    private void Awake()
    {
        _bulletPool = GetComponent<BulletPool>();
    }

    private void Update()
    {
        if (Time.time - _lastAttackTime >= 1 / _attackSpeed)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRange);

            var enemyes = from hit in hitColliders
                          where hit.TryGetComponent(out EnemyHealth enemy)
                          select hit.gameObject;

            if(enemyes.Count() != 0)
            {
                AttackPoint(GetRandomEnemyPosition(enemyes.ToList()));
                _lastAttackTime = Time.time;
            }
        }
    }

    private Vector3 GetRandomEnemyPosition(List<GameObject> enemyes)
    {
        Vector3 point = enemyes[Random.Range(0, enemyes.Count())].transform.position;

        return point;
    }

    private void AttackPoint(Vector3 point)
    {
        if (_bulletPool.TryGetBullet(out Bullet bullet))
        {
            var explosionBullet = bullet as ExplosionBullet;

            explosionBullet.gameObject.SetActive(true);
            explosionBullet.transform.position = _shotPoint.position;
            explosionBullet.SetStats(_damage, _explosionRadius, _maxY);
            explosionBullet.SetTargetPoint(point);
        }
    }
}
