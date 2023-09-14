using UnityEngine;

public class UpgradeStarter : MonoBehaviour
{
    [SerializeField] private PlayerExperience _player;
    [SerializeField] private Canvas _startUpgradeCanvas;

    private void OnEnable()
    {
        _player.LevelUp += OnLevelUp;
    }

    private void OnDisable()
    {
        _player.LevelUp -= OnLevelUp;
    }

    private void OnLevelUp()
    {
        _startUpgradeCanvas.gameObject.SetActive(true);

        Time.timeScale = 0;
    }
}
