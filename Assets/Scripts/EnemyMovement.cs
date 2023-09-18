using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent myAgent;
    private Animator animator;
    private PlayerMovement player;
    public float attackRange = 2f;
    public float damage = 10f;
    public float attackCooldown = 2f;
    private float cooldownTimer = 0f;


    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);


            if (cooldownTimer <= 0f && distanceToPlayer <= attackRange)
            {
                myAgent.isStopped = true;
                animator.SetTrigger("isAttack");

                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                }

                myAgent.isStopped = false;
                cooldownTimer = attackCooldown;
            }
            else
            {
                myAgent.isStopped = false;
                myAgent.destination = player.transform.position;
                animator.ResetTrigger("isAttack");
            }

            cooldownTimer -= Time.deltaTime;
        }
    }
}