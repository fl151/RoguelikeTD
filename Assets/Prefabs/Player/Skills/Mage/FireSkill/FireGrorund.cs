using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FireGrorund : MonoBehaviour
{
    private const float _defaultSphereRadius = 4.5f;

    [SerializeField] private ParticleSystem _effectPrefab;

    private ParticleSystem _effect;

    private int _countHits = 3;
    private float _delayBetweenHits = 0.75f; // �������� ������ 3 �������
    private float _delayBetweenAttacks = 5;

    private float _totalDamage;
    private float _scale;

    public event UnityAction Hited;

    private void Awake()
    {
        _effect = Instantiate(_effectPrefab, transform);
        _effect.Stop();
    }

    private void Start()
    {
        StartCoroutine(PlayAttack());
    }    

    public void SetDamage(float totalDamage)
    {
        _totalDamage = totalDamage;
    }

    public void SetScale(float scale)
    {
        _scale = scale;

        transform.localScale = new Vector3(_scale, _scale, _scale);
    }

    private IEnumerator PlayAttack()
    {
        var halfDelay = new WaitForSeconds(_delayBetweenAttacks / 2);

        while (true)
        {
            yield return halfDelay;
            _effect.Play();

            for (int i = 0; i < _countHits; i++)
            {
                yield return new WaitForSeconds(_delayBetweenHits); 
                AttackAOE();
            }

            yield return halfDelay;
        }
    }

    private void AttackAOE()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _defaultSphereRadius * _scale);

        foreach (var collider in hitColliders)
        {
            if(collider.TryGetComponent(out EnemyHealth enemy))
            {               
                enemy.TakeDamage(_totalDamage / _countHits);
            }
        }

        Hited?.Invoke();
    }

    private void PlaySound()
    {

    }
}
