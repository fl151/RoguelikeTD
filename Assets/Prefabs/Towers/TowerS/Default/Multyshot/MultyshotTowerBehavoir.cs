using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(ObjectPool))]
public class MultyshotTowerBehavoir : MonoBehaviour
{
    private const float _attackRange = 7.5f;

    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private int _countAttacks;
    [SerializeField] private Transform _shotPoint;

    private ObjectPool _bulletPool;
    private float _lastAttackTime = 0;

    private List<GameObject> _currentEnemys = new List<GameObject>();

    private void Awake()
    {
        _bulletPool = GetComponent<ObjectPool>();
    }

    public void SetStats(float damage, float attackSpeed, int countAttacks)
    {
        _damage = damage;
        _attackSpeed = attackSpeed;
        _countAttacks = countAttacks;
    }

    private void Update()
    {
        if(Time.time - _lastAttackTime >= 1 / _attackSpeed)
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
        foreach (var enemy in enemyes)
        {
            AttackEnemy(enemy);
        }
    }

    private void AttackEnemy(GameObject enemy)
    {
        if (_bulletPool.TryGetObject(out GameObject bullet))
        {
            var targetBullet = bullet.GetComponent<TargetBullet>();

            targetBullet.gameObject.SetActive(true);
            targetBullet.transform.position = _shotPoint.position;
            targetBullet.Init(enemy, _damage);
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
