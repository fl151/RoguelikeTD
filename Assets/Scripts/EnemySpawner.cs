using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemmyPrefab;
    [SerializeField] private Transform _spawnPiont;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private int _maxEnemys = 5;

    private int _currentEnemyCount = 0;
    private float _spawnTimer = 0f;

    private void Update()
    {
        if (_currentEnemyCount<_maxEnemys)
        {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer>=_spawnInterval)
            {
                SpawnEnemy();
                _spawnTimer=0f;
            }
        }
    }

    private void SpawnEnemy()
    {
        if (_enemmyPrefab!=null&&_spawnPiont!=null)
        {
            GameObject newEnemy = Instantiate(_enemmyPrefab, _spawnPiont.position, Quaternion.identity);
            _currentEnemyCount++;
        }
    }
}
