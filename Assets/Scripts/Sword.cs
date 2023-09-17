using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float _damagee = 100f;

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(_damagee);
        }
    }
}