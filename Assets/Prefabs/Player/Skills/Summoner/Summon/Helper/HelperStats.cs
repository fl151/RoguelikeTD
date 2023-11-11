using System.Collections;
using UnityEngine;

public class HelperStats : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 25;
    [SerializeField] private float _damage = 30;
    [SerializeField] private float _damageBonus = 0;
    [SerializeField] private float _attackRange = 1.5f;
    [SerializeField] private float _agrRange = 10;
    [SerializeField] private float _attackSpeed = 1;

    [SerializeField] ParticleSystem _addStatsEffect;

    private ParticleSystem _effect;

    public float Damage => _damage + _damageBonus;
    public float AttackRange => _attackRange;
    public float AgrRange => _agrRange;
    public float AttackSpeed => _attackSpeed;
    public float MaxHealth => _maxHealth;

    public void SetStats(float damage, float attackSpeed, float health)
    {
        _maxHealth = health;
        _damage = damage;
        _attackSpeed = attackSpeed;
    }

    public void SetStats(float damage, float attackSpeed)
    {
        _damage = damage;
        _attackSpeed = attackSpeed;

        StartCoroutine(PlayEffect());
    }

    public void AddDamageBonus(float value)
    {
        _damageBonus += value;
    }

    public void RemoveDamageBonus(float value)
    {
        _damageBonus -= value;
    }

    public void OffEffect()
    {
        _effect.Stop();
    }

    private void Awake()
    {
        _effect = Instantiate(_addStatsEffect, transform);
    }

    private IEnumerator PlayEffect()
    {
        _effect.Play();

        yield return new WaitForSeconds(0.75f);

        _effect.Stop();
    }
}
