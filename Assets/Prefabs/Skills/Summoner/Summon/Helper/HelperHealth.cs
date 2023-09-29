using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HelperStats))]
public class HelperHealth : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private HelperStats _stats;
    private float _currentHealth;

    private void Awake()
    {
        _stats = GetComponent<HelperStats>();

        _currentHealth = _stats.MaxHealth;
    }

    private void Update()
    {
        slider.value = _currentHealth;
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
