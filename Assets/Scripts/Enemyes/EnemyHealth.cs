using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyStats))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    private Animator _animator;
    private EnemyStats _stats;
    private SkinnedMeshRenderer _skin;

    private bool _isAlive = true;

    public event UnityAction<EnemyHealth> Dead;

    public bool IsAlive => _isAlive;

    private void Awake()
    {
        _stats = GetComponent<EnemyStats>();
        _skin = GetComponentInChildren<SkinnedMeshRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _isAlive = true;
        _skin.material.color = Color.white;

        _stats.Inited += OnStatsInited;
    }

    private void OnDisable()
    {
        _stats.Inited -= OnStatsInited;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        StartCoroutine(PlayDamageEffect());

        if (_currentHealth <= 0)
        {
            _animator.SetTrigger("isDie");
            _isAlive = false;
            StartCoroutine(Die());
        }
    }

    private IEnumerator PlayDamageEffect()
    {
        Color oldColor = _skin.material.color;

        _skin.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _skin.material.color = oldColor;
    }

    private IEnumerator Die()
    {        
        yield return new WaitForSeconds(0.5f);
        Dead?.Invoke(this);        
        gameObject.SetActive(false);
    }

    private void OnStatsInited()
    {
        _maxHealth = _stats.MaxHealth;

        _currentHealth = _maxHealth;
    }
}