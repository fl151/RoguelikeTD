using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;

    private GameObject target;

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    public void SetDamage(float value)
    {
        _damage = value;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized * 10;
            transform.Translate(direction * Time.deltaTime);

            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

            if (distanceToTarget < 0.1f)
            {
                AttackTarget();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void AttackTarget()
    {
        EnemyHealth enemy = target.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}