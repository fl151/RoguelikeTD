using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyStats _enemmyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private int _maxEnemys = 5;
    [SerializeField] private Experience _expPrefab;
    [SerializeField] private float _chanceDrop;

    private int _currentEnemyCount = 0;
    private float _lastSpawn = 0f;

    private int _difficulty = 0;
    private ExperienceDroper _expDroper;

    private ObjectPool<EnemyStats> _enemyPool;

    public event UnityAction DifficultyUp;
    public event UnityAction<EnemyHealth> EnemySpawned;

    private void Awake()
    {
        _enemyPool = new ObjectPool<EnemyStats>(_enemmyPrefab, 10, transform, true);
        _expDroper = new ExperienceDroper(this, _expPrefab, 1, transform);
    }

    private void Update()
    {
        if (_currentEnemyCount < _maxEnemys)
        {
            if (Time.time - _lastSpawn >= _spawnInterval)
            {
                SpawnEnemy();

                if (_currentEnemyCount % 10 == 0)
                {
                    UpDifficulty();
                }

                _lastSpawn = Time.time;
            }
        }
    }

    private void SpawnEnemy()
    {
        var position = GetRandomSpawnPoint(_spawnPoints).position;

        EnemyStats enemy = _enemyPool.GetFreeElement();

        enemy.transform.position = position;
        enemy.Init(this, _difficulty);

        EnemySpawned?.Invoke(enemy.GetComponent<EnemyHealth>());
        _currentEnemyCount++;
    }

    private Transform GetRandomSpawnPoint(Transform[] spanwPoints)
    {
        if (spanwPoints.Length == 0) return null;

        return spanwPoints[Random.Range(0, spanwPoints.Length)];
    }

    private void UpDifficulty()
    {
        _difficulty++;
        DifficultyUp?.Invoke();
    }
}
