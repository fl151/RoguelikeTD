using UnityEngine;
using UnityEngine.Events;

public class PlayerExperience : MonoBehaviour
{
    private const float _firstLevelExp = 100;
    private const float _coefficientNextLevelExp = 1.2f;

    private float _currentExp = 0;
    private float _currentLevel = 1;
    private float _currentTargetExp;

    public float ShareOfNextLevel => _currentExp / _currentTargetExp;
    public float CurrentLevel => _currentLevel;

    public event UnityAction LevelUp;
    public event UnityAction ExpGained;

    private void Awake()
    {
        _currentTargetExp = _firstLevelExp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Experience exp))
        {
            AddExp(exp.Count);
            Destroy(exp.gameObject);
        }
    }

    private void AddExp(float count)
    {
        _currentExp += count;

        if(_currentExp >= _currentTargetExp)
        {
            UpLevel();
        }

        ExpGained?.Invoke();
    }

    private void UpLevel()
    {
        _currentExp -= _currentTargetExp;
        _currentTargetExp *= _coefficientNextLevelExp;

        _currentLevel++;

        LevelUp?.Invoke();
    }
}
