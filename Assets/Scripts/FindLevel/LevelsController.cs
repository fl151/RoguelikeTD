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
        TryUpgradeData();

        LevelUpgrade?.Invoke();
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
        SceneManager.LoadScene(3);
    }

    public void PassLevel()
    {
        var nextLevel = _playingLevel.NextLevel;

        if (nextLevel != null)
            _levelsDic[nextLevel] = true;

        LevelUpgrade?.Invoke();

        Progress.Instance.PlayerData.CountLevelsOpened++;
        Progress.SaveDataCloud();
    }

    private void AddLevelsInDic()
    {
        if(_levelsDic.Count == 0)
        {
            foreach (var level in _levels)
            {
                _levelsDic.Add(level, level.OpenAsDefault);
            }
        }
    }

    private void TryUpgradeData()
    {
        var data = Progress.Instance.PlayerData;

        if (data != default)
        {
            int i = 0;
            var levels = new Dictionary<Level, bool>();

            foreach (var level in _levelsDic)
            {
                if (i < 4)//data.CountLevelsOpened
                    levels[level.Key] = true;
                else
                    levels[level.Key] = false;

                i++;
            }

            _levelsDic = levels;
        }
    }
}
