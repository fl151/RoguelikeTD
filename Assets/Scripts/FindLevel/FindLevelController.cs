using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FindLevelController : MonoBehaviour
{
    public static FindLevelController Instance;

    private Level _currentLevel;

    public event UnityAction NewLevel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool TrySetLevel(Level level)
    {
        if (level == null) return false;

        if(_currentLevel == null || _currentLevel != level)
        {
            NewLevel?.Invoke();

            _currentLevel = level;
            return true;
        }

        return false;
    }

    public void FindLevel()
    {
        if(_currentLevel != null)
        {
            LevelsController.Instance.SetPlayingLevel(_currentLevel);
        }
    }
}
