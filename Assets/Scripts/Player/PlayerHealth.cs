using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerStats))]
public class PlayerHealth : Health
{
    [SerializeField] private Slider slider;

    private float _currentHealth;

    private PlayerStats _playerStats;

    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();

        _currentHealth = _playerStats.Health;
    }

    private void Update()
    {
        slider.value = _currentHealth;
    }

    public override void TakeDamage(float damage)
    {
        if (damage < 0) return;

        _currentHealth -= damage * (1 - _playerStats.Armor);

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