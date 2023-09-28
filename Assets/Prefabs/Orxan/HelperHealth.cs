using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public Slider slider;

    private void Update()
    {
        slider.value = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        maxHealth -= damage;

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
