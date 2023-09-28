using UnityEngine;
using UnityEngine.AI;

public class HelperMovement : MonoBehaviour
{
    private NavMeshAgent myAgent;
    private Animator animator;
    private EnemyMovement enemy;
    public float attackRange = 2f;
    public float damage = 10f;
    public float attackCooldown = 2f;
    private float cooldownTimer = 0f;


    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemy = FindObjectOfType<EnemyMovement>();
    }

    private void Update()
    {
        if (enemy != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, enemy.transform.position);


            if (cooldownTimer <= 0f && distanceToPlayer <= attackRange)
            {
                myAgent.isStopped = true;
                animator.SetTrigger("isAttack");

                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }

                myAgent.isStopped = false;
                cooldownTimer = attackCooldown;
            }
            else
            {
                myAgent.isStopped = false;
                myAgent.destination = enemy.transform.position;
                animator.ResetTrigger("isAttack");
            }

            cooldownTimer -= Time.deltaTime;
        }
    }
}