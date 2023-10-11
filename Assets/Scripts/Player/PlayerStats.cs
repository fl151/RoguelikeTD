using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _armor;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackRangeMeele;

    public event UnityAction StatsChanged;

    public float Health => _health;
    public float Armor => Mathf.Clamp01(_armor);
    public float Damage => _damage;
    public float AttackSpeed => _attackSpeed;
    public float AttackRange => _attackRange;
    public float AttackRangeMeele => _attackRangeMeele;

    public void AddDamage(float value)
    {
        if (value > 0)
        {
            _damage += value;
            StatsChanged?.Invoke();
        }
    }
    
    public void AddArmor(float value)
    {
        if (value > 0)
        {
            _armor += value;
            StatsChanged?.Invoke();
        }
    }
    
    public void AddAttackSpeed(float value)
    {
        if (value > 0)
        {
            _attackSpeed += value;
            StatsChanged?.Invoke();
        }
    }
}
