using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent myAgent;
    private Animator animator;
    private Health _target;
    public float attackRange = 2f;
    public float damage = 10f;
    public float attackCooldown = 2f;
    private float cooldownTimer = 0f;

    private float _agrRange = 100f;

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _agrRange);

        var enemyGameObject = FindNearestTarget(hitColliders);

        if (enemyGameObject != null)
            _target = enemyGameObject.GetComponent<Health>();

        if(_target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);

            if (cooldownTimer <= 0f && distanceToTarget <= attackRange)
            {
                myAgent.isStopped = true;
                animator.SetTrigger("isAttack");

                Health targetHealth = _target.GetComponent<Health>();

                if (targetHealth != null)
                {
                    targetHealth.TakeDamage(damage);
                }

                cooldownTimer = attackCooldown;
            }
            else
            {
                myAgent.isStopped = false;
                myAgent.destination = _target.transform.position;
                animator.ResetTrigger("isAttack");
            }
        }

        cooldownTimer -= Time.deltaTime;

    }

    private GameObject FindNearestTarget(Collider[] colliders)
    {
        GameObject nearestTarget = null;
        float nearestDistance = float.MaxValue;

        foreach (Collider collider in colliders)
        {
            Health target = collider.GetComponent<Health>();

            if (target != null && collider.gameObject.activeSelf)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);

                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestTarget = collider.gameObject;
                }
            }
        }

        return nearestTarget;
    }
}