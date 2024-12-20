using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyStats> _enemyPrefabs;    
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private int _maxEnemys = 5;
    [SerializeField] private Experience _expPrefab;
    [SerializeField] private Experience _bigExpPrefab;
    [SerializeField] private float _chanceDrop;
    [SerializeField] private float _chanceDropBig;

    public int CurrentEnemyCount => _currentEnemyCount;
    public int MaxEnemyCount => _maxEnemys;

    private int _currentEnemyCount = 0;
    private float _lastSpawn = 0f;
    private bool _lastEnemyDied = false;

    private ExperienceDroper _expDroper;
    private EnemyHealth _lastEnemy;

    private List<ObjectPool<EnemyStats>> _enemyPools = new List<ObjectPool<EnemyStats>>();

    public event UnityAction<EnemyHealth> EnemySpawned;
    public event UnityAction LastEnemyDied;

    private void Awake()
    {
        for (int i = 0; i < _enemyPrefabs.Count; i++)
            _enemyPools.Add(new ObjectPool<EnemyStats>(_enemyPrefabs[i], 5, transform, true));

        _expDroper = new ExperienceDroper(this, _expPrefab, _bigExpPrefab, _chanceDrop, _chanceDropBig,  transform);        
    }

    private void OnDisable()
    {
        if (_lastEnemy != null)
            _lastEnemy.Dead -= OnLastEnemyDead;
    }

    private void FixedUpdate()
    {
        if (_lastEnemyDied)
        {
            int activeElements = 0;

            for (int i = 0; i < _enemyPools.Count; i++)
                activeElements += _enemyPools[i].GetActiveElements().Count;

            if (activeElements == 0)
                LastEnemyDied?.Invoke();
        }     
    }

    private void Update()
    {
        if (_currentEnemyCount < _maxEnemys)
        {
            if (Time.time - _lastSpawn >= _spawnInterval)
            {
                for (int i = 0; i < 3; i++)
                {
                    SpawnEnemy();
                }                   

                _lastSpawn = Time.time;
            }
        }
    }

    private void SpawnEnemy()
    {
        var position = GetRandomSpawnPoint(_spawnPoints).position;

        EnemyStats enemy = GetRandomEnemyPool(_enemyPools).GetFreeElement();

        enemy.transform.position = position;
        enemy.Init(this);

        EnemySpawned?.Invoke(enemy.GetComponent<EnemyHealth>());
        _currentEnemyCount++;

        if (_currentEnemyCount == _maxEnemys)
        {
            _lastEnemy = enemy.GetComponent<EnemyHealth>();
            _lastEnemy.Dead += OnLastEnemyDead;
        }
    }

    private Transform GetRandomSpawnPoint(Transform[] spanwPoints)
    {
        if (spanwPoints.Length == 0) return null;

        return spanwPoints[Random.Range(0, spanwPoints.Length)];
    }

    private ObjectPool<EnemyStats> GetRandomEnemyPool(List<ObjectPool<EnemyStats>> pools)
    {
        if (pools.Count == 0) return null;

        return pools[Random.Range(0, pools.Count)];
    }

    private void OnLastEnemyDead(EnemyHealth enemy)
    {
        enemy.Dead -= OnLastEnemyDead;
        _lastEnemyDied = true;
    }
}
