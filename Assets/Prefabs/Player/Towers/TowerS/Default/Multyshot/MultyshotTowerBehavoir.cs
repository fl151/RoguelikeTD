using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MultyshotTowerBehavoir : ShootingTowerBehavoir
{
    private const float _attackRange = 5.0f;

    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private int _countAttacks;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private TargetBullet _bulletPrefab;
    [SerializeField] private int _countBullets = 8;

    private ObjectPool<TargetBullet> _bulletPool;
    private float _lastAttackTime = 0;

    private List<GameObject> _currentEnemys = new List<GameObject>();

    private void Awake()
    {
        _bulletPool = new ObjectPool<TargetBullet>(_bulletPrefab, _countBullets, transform, true);
    }

    public void SetStats(float damage, float attackSpeed, int countAttacks)
    {
        _damage = damage;
        _attackSpeed = attackSpeed;
        _countAttacks = countAttacks;
    }

    private void Update()
    {
        if (Time.time - _lastAttackTime >= 1 / _attackSpeed)
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

                    if (_currentEnemys.Contains(newEnemy)) break;

                    _currentEnemys.Add(newEnemy);
                }

                if (_currentEnemys.Count > 0)
                {
                    _target = _currentEnemys[0];
                }
                else
                {
                    _target = null;
                }
            }

            if (_currentEnemys.Count() != 0)
            {
                AttackEnemys(_currentEnemys);
                _lastAttackTime = Time.time;
            }
        }

    }

    private void AttackEnemys(List<GameObject> enemyes)
    {
        var incorrectEnemyes = new List<GameObject>();

        foreach (var enemy in enemyes)
        {
            if (IsEnemyCorrect(enemy))
                AttackEnemy(enemy);
            else
                incorrectEnemyes.Add(enemy);
        }

        foreach (var incorrectEnemy in incorrectEnemyes)
        {
            _currentEnemys.Remove(incorrectEnemy);
        }
    }

    private void AttackEnemy(GameObject enemy)
    {
        var targetBullet = _bulletPool.GetFreeElement();

        targetBullet.transform.position = _shotPoint.position;
        targetBullet.Init(enemy, _damage);
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
