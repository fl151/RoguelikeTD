using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    private Animator _animator;
    private EnemyStats _stats;
    private SkinnedMeshRenderer _skin;

    private bool _isAlive = true;

    public bool IsAlive => _isAlive;

    private void Awake()
    {
        _stats = GetComponent<EnemyStats>();

        _skin = GetComponentInChildren<SkinnedMeshRenderer>();
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

        StartCoroutine(PlayDamageEffect());

        if (_currentHealth <= 0)
        {
            _animator.SetTrigger("isDie");
            _isAlive = false;
            Destroy(gameObject, 0.5f);
        }
    }

    private IEnumerator PlayDamageEffect()
    {
        Color oldColor = _skin.material.color;
        Material oldMaterial = _skin.material;

        _skin.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        if (oldMaterial == _skin.material)
            _skin.material.color = oldColor;
    }
}