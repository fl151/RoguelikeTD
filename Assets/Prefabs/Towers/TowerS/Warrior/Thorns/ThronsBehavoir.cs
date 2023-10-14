using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThronsBehavoir : MonoBehaviour
{
    [SerializeField] private float _damage = 5;
    [SerializeField] private float _slowCoef = 0.5f;

    private HashSet<EnemyStats> _enemyes = new HashSet<EnemyStats>();

    public void SetStats(float damage, float slowCoef)
    {
        RemoveSlow(slowCoef);

        _damage = damage;
        _slowCoef = slowCoef;

        AddSlow(slowCoef);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyStats enemy))
        {
            if (_enemyes.Contains(enemy) == false)
            {
                //enemy.AddDamageBonus(_damageBonus);
                _enemyes.Add(enemy);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out EnemyStats enemy))
        {
            //enemy.RemoveDamageBonus(_damageBonus);
            _enemyes.Remove(enemy);
        }
    }

    private void RemoveSlow(float slowCoef)
    {
        foreach (var enemy in _enemyes)
        {
            //enemy.RemoveDamageBonus(value);
        }
    }

    private void AddSlow(float slowCoef)
    {
        foreach (var enemy in _enemyes)
        {
            //helper.AddDamageBonus(value);
        }
    }
}
