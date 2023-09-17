using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroMeeleAttack : MonoBehaviour
{
    [SerializeField] private float _attackRange = 5f;
    [SerializeField] private float _attackCooldown = 2f;

    private float _lastAttackTime = 0f;

    public event UnityAction Attack;
    public event UnityAction NotAttack;

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRange);

        if (hitColliders.Length > 0)
        {
            if (Time.time - _lastAttackTime >= _attackCooldown)
            {
                Attack?.Invoke();
                _lastAttackTime = Time.time;
            }
        }
        else
        {
            NotAttack?.Invoke();
        }
    }
}