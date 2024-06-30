using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;

public class GameResultController : MonoBehaviour
{
    private const float _adChance = 50;

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
        _loseCanvas.SetActive(true);

        StartCoroutine(ShowAd());
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

    private IEnumerator ShowAd()
    {
        yield return new WaitForSeconds(0.25f);

        int randomChance = Random.Range(0, 100);

        if (randomChance < _adChance)
            InterstitialAd.Show(OpenCallback, CloseCallback);
    }
}