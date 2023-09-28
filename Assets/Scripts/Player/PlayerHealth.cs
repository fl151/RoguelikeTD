using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerArmor))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;

    [SerializeField] private Slider slider;

    private PlayerArmor _playerArmor;

    private void Awake()
    {
        _playerArmor = GetComponent<PlayerArmor>();
    }

    private void Update()
    {
        slider.value = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0) return;

        maxHealth -= damage * (1 - _playerArmor.Armor);

        if (maxHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Destroy(gameObject);
    }
}