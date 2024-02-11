using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerStats))]
public class PlayerHealth : Health
{
    [SerializeField] private Slider slider;

    private float _time;
    private const float _timeBeforeHeal = 3f;
    private const float _healPerSecond = 3f;
    private float _maxHealth;

    private float _currentHealth;

    private PlayerStats _playerStats;

    public event UnityAction Died;


    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
        _maxHealth = _playerStats.Health;
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        slider.value = _currentHealth;
        if (Time.time - _time >= _timeBeforeHeal)
        {
            RegeneretionHealth();
        }
    }

    public override void TakeDamage(float damage)
    {
        if (damage < 0) return;

        _currentHealth -= damage * (1 - _playerStats.Armor);
        _time = Time.time;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void RegeneretionHealth()
    {
        _currentHealth += _healPerSecond * Time.deltaTime;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
    }

    void Die()
    {
        Died?.Invoke();

        Destroy(gameObject);
    }
}