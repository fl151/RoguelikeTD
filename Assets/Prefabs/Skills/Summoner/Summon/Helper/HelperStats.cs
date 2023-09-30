using System.Collections;
using UnityEngine;

public class HelperStats : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 25;
    [SerializeField] private float _damage = 30;
    [SerializeField] private float _attackRange = 10;
    [SerializeField] private float _attackSpeed = 1;

    [SerializeField] ParticleSystem _addStatsEffect;

    private ParticleSystem _effect;

    public float Damage => _damage;
    public float AttackRange => _attackRange;
    public float AttackSpeed => _attackSpeed;
    public float MaxHealth => _maxHealth;

    public void SetStats(float damage, float attackSpeed, float health)
    {
        _maxHealth = health;
        _damage = damage;
        _attackSpeed = attackSpeed;
    }

    public void AddStats(float damage, float attackSpeed)
    {
        _damage = damage;
        _attackSpeed = attackSpeed;

        StartCoroutine(PlayEffect());
    }

    private void Awake()
    {
        _effect = Instantiate(_addStatsEffect, transform);
        _effect.Stop();
    }

    private IEnumerator PlayEffect()
    {
        _effect.Play();

        yield return new WaitForSeconds(0.75f);

        _effect.Stop();
    }
}
