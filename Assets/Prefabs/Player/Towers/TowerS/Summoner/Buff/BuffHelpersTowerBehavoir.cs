using System.Collections.Generic;
using UnityEngine;

public class BuffHelpersTowerBehavoir : MonoBehaviour
{
    [SerializeField] private float _damageBonus = 1;

    private HashSet<HelperStats> _helpers = new HashSet<HelperStats>();

    public void SetDamageBonus(float damage)
    {
        RemoveDamageBonus(_damageBonus);

        _damageBonus = damage;

        AddDamageBonus(_damageBonus);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HelperStats helper))
        {
            if(_helpers.Contains(helper) == false)
            {
                helper.AddDamageBonus(_damageBonus);
                _helpers.Add(helper);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out HelperStats helper))
        {
            helper.RemoveDamageBonus(_damageBonus);
            _helpers.Remove(helper);
        }
    }

    private void RemoveDamageBonus(float value)
    {
        foreach (var helper in _helpers)
        {
            helper.RemoveDamageBonus(value);
        }
    }

    private void AddDamageBonus(float value)
    {
        foreach (var helper in _helpers)
        {
            helper.AddDamageBonus(value);
        }
    }
}
