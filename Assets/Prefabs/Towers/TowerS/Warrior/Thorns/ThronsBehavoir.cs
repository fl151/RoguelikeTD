using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThronsBehavoir : MonoBehaviour
{
    private const float _damageDelay = 1f;
    private const float _radius = 0.5f;

    [SerializeField] private float _damage = 5;
    [Range(0, 1)]
    [SerializeField] private float _slowCoef = 0.2f;

    private HashSet<EnemyMovement> _enemyes = new HashSet<EnemyMovement>();

    private void Start()
    {
        StartCoroutine(DamageCoroutine());
    }

    public void SetStats(float damage, float slowCoef)
    {
        RemoveSlow(slowCoef);

        _damage = damage;
        _slowCoef = slowCoef;

        AddSlow(slowCoef);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyMovement enemy))
        {
            if (_enemyes.Contains(enemy) == false)
            {
                enemy.AddSlow(_slowCoef);
                _enemyes.Add(enemy);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out EnemyMovement enemy))
        {
            enemy.RemoveSlow(_slowCoef);
            _enemyes.Remove(enemy);
        }
    }

    private void RemoveSlow(float slowCoef)
    {
        foreach (var enemy in _enemyes)
        {
            enemy.RemoveSlow(slowCoef);
        }
    }

    private void AddSlow(float slowCoef)
    {
        foreach (var enemy in _enemyes)
        {
            enemy.AddSlow(slowCoef);
        }
    }

    private IEnumerator DamageCoroutine()
    {
        var halfDelay = new WaitForSeconds(_damageDelay / 2);

        while (true)
        {
            yield return halfDelay;

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius);

            foreach (var collider in hitColliders)
            {
                if (collider.TryGetComponent(out EnemyHealth enemy))
                {
                    enemy.TakeDamage(_damage);
                }
            }

            yield return halfDelay;
        }
    }
}
