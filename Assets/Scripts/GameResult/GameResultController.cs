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
        PauseManager.Instance.Pause();
        _loseCanvas.SetActive(true);
    }

    private void WinGame()
    {
        PauseManager.Instance.Pause();
        LevelsController.Instance.PassLevel();
        _winCanvas.SetActive(true);
    } 
}