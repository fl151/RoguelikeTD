using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperStats : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _damage = 30;
    [SerializeField] private float _attackRange = 10;
    [SerializeField] private float _attackSpeed = 1;

    public float Damage => _damage;
    public float AttackRange => _attackRange;
    public float AttackSpeed => _attackSpeed;
    public float MaxHealth => _maxHealth;
}
