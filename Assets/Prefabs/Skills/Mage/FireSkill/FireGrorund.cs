using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrorund : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectPrefab;
    [SerializeField] private Collider[] _colliders;

    private ParticleSystem _effect;

    private int _countHits;
    private float _delayBetweenHits;
    private float _delayBetweenAttacks = 5;

    [SerializeField] private float _totalDamage;

    private void Awake()
    {
        _effect = Instantiate(_effectPrefab, transform);
        _effect.Stop();

        _countHits = _colliders.Length;
        _delayBetweenHits = 3 / _countHits;
    }

    private void Start()
    {
        StartCoroutine(PlayAttack());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(_totalDamage / _countHits);
            Debug.Log(enemyHealth);
        }
    }

    public void SetDamage(float totalDamage)
    {
        _totalDamage = totalDamage;
    }

    private IEnumerator PlayAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delayBetweenAttacks / 2);

            for (int i = 0; i < _countHits; i++)
            {
                if(_colliders.Length > i && _colliders[i] != null)
                {
                    yield return new WaitForSeconds(_delayBetweenHits);
                    StartAttackAOE(i);

                    yield return new WaitForFixedUpdate();
                    FinishAOEAttack(i);
                }
            }

            yield return new WaitForSeconds(_delayBetweenAttacks / 2);
        }
    }

    private void StartAttackAOE(int index)
    {
        _colliders[index].enabled = true;
        _effect.Play();
    }

    private void FinishAOEAttack(int index)
    {
        _colliders[index].enabled = false;
    }
}
