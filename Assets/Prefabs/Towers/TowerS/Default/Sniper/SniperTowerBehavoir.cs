using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTowerBehavoir : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackRange;
    [SerializeField] private TargetBullet _bulletPrefab;

    [SerializeField] private Transform _shotPoint;

    private GameObject _currentEnemy;

    private float _lastAttackTime = 0;

    public void SetStats(float damage, float attackSpeed, float attackRange)
    {
        _damage = damage;
        _attackSpeed = attackSpeed;
        _attackRange = attackRange;
    }

    private void Update()
    {
        if (_currentEnemy == null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRange);

            _currentEnemy = FindNearestEnemy(hitColliders);
        }
        else
        {
            if (Time.time - _lastAttackTime >= 1 / _attackSpeed)
            {
                AttackEnemy(_currentEnemy);
                _lastAttackTime = Time.time;
            }
        }
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
        TargetBullet bullet = Instantiate(_bulletPrefab, _shotPoint.position, Quaternion.identity);
        bullet.SetTarget(enemy);
        bullet.SetDamage(_damage);
    }
}
