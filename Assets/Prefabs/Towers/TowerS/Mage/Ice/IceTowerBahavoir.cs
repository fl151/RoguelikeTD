using UnityEngine;
using System.Linq;

[RequireComponent(typeof(ObjectPool))]
public class IceTowerBahavoir : MonoBehaviour
{
    private const float _attackRange = 7.5f;

    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _slowCoefficient;

    [SerializeField] private Transform _shotPoint;

    private ObjectPool _bulletPool;
    private GameObject _currentEnemy;

    private float _lastAttackTime = 0;

    public void SetStats(float damage, float attackSpeed, float slowCoefficient)
    {
        _damage = damage;
        _attackSpeed = attackSpeed;
        _slowCoefficient = slowCoefficient;
    }

    private void Awake()
    {
        _bulletPool = GetComponent<ObjectPool>();
    }

    private void Update()
    {
        if (Time.time - _lastAttackTime >= 1 / _attackSpeed)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRange);

            var enemyes = from hit in hitColliders
                          where hit.TryGetComponent(out EnemyHealth enemy)
                          select hit.gameObject;

            _currentEnemy = GetRandomEnemy(enemyes.ToArray());

            if (_currentEnemy != null)
            {
                AttackEnemy(_currentEnemy);
                _lastAttackTime = Time.time;
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
        if (_bulletPool.TryGetObject(out GameObject bullet))
        {
            var targetBullet = bullet.GetComponent<IceBullet>();

            targetBullet.gameObject.SetActive(true);
            targetBullet.transform.position = _shotPoint.position;
            targetBullet.Init(enemy, _damage);
            targetBullet.SetSlowCoefficient(_slowCoefficient);
        }
    }
}
