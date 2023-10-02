using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MultyshotTowerBehavoir : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private int _countAttacks;
    [SerializeField] private TargetBullet _bulletPrefab;

    [SerializeField] private Transform _shotPoint;

    private float _attackRange = 7.5f;

    private List<GameObject> _currentEnemys = new List<GameObject>();

    private float _lastAttackTime = 0;

    public void SetStats(float damage, float attackSpeed, int countAttacks)
    {
        _damage = damage;
        _attackSpeed = attackSpeed;
        _countAttacks = countAttacks;
    }

    private void Update()
    {
        RemoveDiedEnemyes();

        if (_currentEnemys.Count() < _countAttacks)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRange);

            var enemyes = from hit in hitColliders
                          where hit.TryGetComponent(out EnemyHealth enemy)
                          select hit.gameObject;

            var enemyesList = enemyes.ToList();

            while (enemyesList.Count() != 0 && _currentEnemys.Count() < _countAttacks)
            {
                var newEnemy = TakeRandomEnemy(enemyesList);

                _currentEnemys.Add(newEnemy);
            }
        }

        if (_currentEnemys.Count() != 0 && Time.time - _lastAttackTime >= 1 / _attackSpeed)
        {
            AttackEnemys(_currentEnemys);
            _lastAttackTime = Time.time;
        }
    }

    private void AttackEnemys(List<GameObject> enemyes)
    {
        foreach (var enemy in enemyes)
        {
            TargetBullet bullet = Instantiate(_bulletPrefab, _shotPoint.position, Quaternion.identity);
            bullet.SetTarget(enemy);
            bullet.SetDamage(_damage);
        }
    }

    private GameObject TakeRandomEnemy(List<GameObject> enemyes)
    {
        if (enemyes.Count() == 0) return null;

        var enemy = enemyes[Random.Range(0, enemyes.Count())];

        enemyes.Remove(enemy);

        return enemy;
    }

    private void RemoveDiedEnemyes()
    {
        for (int i = 0; i < _currentEnemys.Count(); i++)
        {
            if (_currentEnemys[i] == null) _currentEnemys.RemoveAt(i);
        }
    }
}
