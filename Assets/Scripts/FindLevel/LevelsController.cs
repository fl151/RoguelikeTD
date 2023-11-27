using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelsController : MonoBehaviour
{
    [SerializeField] private List<Level> _levels;

    private Dictionary<Level, bool> _levelsDic;

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
    }

    private void Start()
    {
        AddLevelsInDic();
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
