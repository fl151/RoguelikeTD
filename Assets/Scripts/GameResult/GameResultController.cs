using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultController : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private PlayerHealth _player;

    [Space]
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _loseCanvas;

    private void OnEnable()
    {
        _enemySpawner.LastEnemyDied += OnLastEnemyDied;
        _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _enemySpawner.LastEnemyDied -= OnLastEnemyDied;
        _player.Died -= OnPlayerDied;
    }

    private void OnLastEnemyDied()
    {
        WinGame();
    }

    private void OnPlayerDied()
    {
        LoseGame();
    }

    private void LoseGame()
    {
        Time.timeScale = 0;
        //показать рекламу с каким-то шансом
        _loseCanvas.SetActive(true);
    }

    private void WinGame()
    {
        Time.timeScale = 0;
        LevelsController.Instance.PassLevel();
        _winCanvas.SetActive(true);
    }
}
