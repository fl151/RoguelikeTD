using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
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

        int randomChance = Random.Range(0, 100);//------------------

        if (randomChance < 50)
        {
            InterstitialAd.Show(OpenCallback, CloseCallback);
        }

        //показать рекламу с каким-то шансом
        _loseCanvas.SetActive(true);
    }

    private void WinGame()
    {
        Time.timeScale = 0;
        LevelsController.Instance.PassLevel();
        _winCanvas.SetActive(true);
    }


    private void OpenCallback()
    {
        PauseManager.Instance.Pause();

        AudioListener.pause = true;
        AudioListener.volume = 0f;
    }

    private void CloseCallback(bool isClose)
    {
        AudioListener.pause = false;
        AudioListener.volume = 1f;

        PauseManager.Instance.Unpause();
    }
}