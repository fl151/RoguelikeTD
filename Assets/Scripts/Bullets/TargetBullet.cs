using UnityEngine;

public class TargetBullet : Bullet
{
    private float _damage;

    private GameObject _target;

    public GameObject Target => _target;

    public void Init(GameObject target, float damage)
    {
        _target = target;
        _damage = damage;
    }

    private void Update()
    {
        if (_target.activeSelf)
        {
            Vector3 direction = (_target.transform.position - transform.position).normalized * 10;
            transform.position += direction * Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
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