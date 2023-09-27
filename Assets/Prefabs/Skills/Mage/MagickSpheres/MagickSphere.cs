using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagickSphere : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _effects;

    private ParticleSystem _currentEffect;

    private float _damage;

    public void SetDamage(float value)
    {
        _damage = value;
    }

    public void SetEffect(int levelIndex)
    {
        if(_currentEffect != null)
            Destroy(_currentEffect.gameObject);

        _currentEffect =  Instantiate(_effects[levelIndex], transform);
        _currentEffect.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }
}
