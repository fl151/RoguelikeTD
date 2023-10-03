using UnityEngine;

public class TargetBullet : Bullet
{
    private float _damage;

    private GameObject _target;

    public void SetTarget(GameObject newTarget)
    {
        _target = newTarget;
    }

    public void SetDamage(float value)
    {
        _damage = value;
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = (_target.transform.position - transform.position).normalized * 10;
            transform.Translate(direction * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _target)
            AttackTarget();
    }

    protected virtual void ActionHitEffect(EnemyHealth enemyTarget) { }

    private void AttackTarget()
    {
        EnemyHealth enemy = _target.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            ActionHitEffect(enemy);

            enemy.TakeDamage(_damage);
        }

        gameObject.SetActive(false);
    }
}