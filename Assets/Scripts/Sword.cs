using System;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float _damage;

    private PlayerStats _player;

    private void Awake()
    {
        _player = GetComponentInParent<PlayerStats>();
        _damage = _player.Damage;
    }

    private void OnEnable()
    {
        _player.StatsChanged += OnStatsChanged;
    }  

    private void OnDisable()
    {
        _player.StatsChanged -= OnStatsChanged;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(_damage);
        }
    }

    private void OnStatsChanged()
    {
        _damage = _player.Damage;
    }
}