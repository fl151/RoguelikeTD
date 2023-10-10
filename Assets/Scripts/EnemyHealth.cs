using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    private Animator _animator;

    private EnemyStats _stats;

    private void Awake()
    {
        _stats = GetComponent<EnemyStats>();
    }

    void Start()
    {
        _maxHealth = _stats.MaxHealth;

        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _animator.SetTrigger("isDie");
            Destroy(gameObject,0.5f);
        }
    }    
}