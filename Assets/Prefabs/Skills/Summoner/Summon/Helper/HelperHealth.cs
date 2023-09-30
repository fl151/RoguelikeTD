using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HelperStats))]
public class HelperHealth : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private HelperStats _stats;
    private float _currentHealth;
    private float _maxHealth;

    private void Awake()
    {
        _stats = GetComponent<HelperStats>();

        _currentHealth = _stats.MaxHealth;
        _maxHealth = _stats.MaxHealth;
    }

    private void Update()
    {
        slider.value = _currentHealth / _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Destroy(gameObject);
    }
}
