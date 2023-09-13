using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerExperience : MonoBehaviour
{
    private const float _firstLevelExp = 100;
    private const float _coefficientNextLevelExp = 1.2f;

    private float _currentExp = 0;
    private float _currentTargetExp;

    public float ShareOfNextLevel => _currentExp / _currentTargetExp;

    public event UnityAction LevelUp;
    public event UnityAction ExpGained;

    private void Start()
    {
        _currentTargetExp = _firstLevelExp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Experience exp))
        {
            AddExp(exp.Count);
            Destroy(exp);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Experience exp))
        {
            AddExp(exp.Count);
            Destroy(exp);
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

        LevelUp?.Invoke();
    }
}
