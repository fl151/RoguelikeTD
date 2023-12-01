using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelsController : MonoBehaviour
{
    [SerializeField] private List<Level> _levels;

    private Dictionary<Level, bool> _levelsDic = new Dictionary<Level, bool>();

    private Level _playingLevel;

    public int LevelSceneIndex => _playingLevel.SceneIndex;

    public static LevelsController Instance;

    public event UnityAction LevelUpgrade;

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

        DontDestroyOnLoad(gameObject);

        AddLevelsInDic();
    }

    public Dictionary<Level, bool> GetLevels()
    {
        var levels = new Dictionary<Level, bool>();

        foreach (var levelPair in _levelsDic)
        {
            levels.Add(levelPair.Key, levelPair.Value);
        }

        return levels;
    }

    public void SetPlayingLevel(Level level)
    {
        _playingLevel = level;
        SceneManager.LoadScene(1);
    }

    private void AddLevelsInDic()
    {
        foreach (var level in _levels)
        {
            _levelsDic.Add(level, level.IsBlockedAsDefault);
        }

        LevelUpgrade?.Invoke();
    }
}
