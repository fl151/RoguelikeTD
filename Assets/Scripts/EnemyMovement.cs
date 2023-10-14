using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyStats))]
public class EnemyMovement : MonoBehaviour
{
    private const float attackRange = 1;
    private const float _agrRange = 100f;

    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _attackCooldown = 2f;

    private NavMeshAgent myAgent;
    private Animator animator;
    private Health _target;
    private float cooldownTimer = 0f;

    private float _defaultSpeed;

    private EnemyStats _stats;
    private EnemyHealth _health;

    private void Awake()
    {
        _stats = GetComponent<EnemyStats>();
        _health = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        _stats.StatsChanged += OnStatsChanged;
    }

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        _defaultSpeed = myAgent.speed;

        OnStatsChanged();

        StartCoroutine(FindTargetCoroutine());
    }

    private void Update()
    {
        if (_target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);

            if (cooldownTimer <= 0f && distanceToTarget <= attackRange)
            {
                myAgent.isStopped = true;
                animator.SetTrigger("isAttack");

                Health targetHealth = _target.GetComponent<Health>();

                if (targetHealth != null)
                {
                    StartCoroutine(Attack(targetHealth));
                }

                cooldownTimer = _attackCooldown;
            }
            else
            {
                myAgent.isStopped = false;
                myAgent.destination = _target.transform.position;
                animator.ResetTrigger("isAttack");
            }
        }
        else
        {
            FindNewTarget();
        }

        cooldownTimer -= Time.deltaTime;
    }

    private void OnDisable()
    {
        _stats.StatsChanged -= OnStatsChanged;
    }

    public void MakeSlow(float slowCoefficient)
    {
        myAgent.speed = _defaultSpeed * (1 - slowCoefficient);
    }

    public void MakeNormalSpeed()
    {
        myAgent.speed = _defaultSpeed;
    }

    public void AddSlow(float slowSpeed)
    {
        float minSpeed = 0.2f * _defaultSpeed;

        if(myAgent.speed - slowSpeed >= minSpeed)
            myAgent.speed -= slowSpeed;
        else
            myAgent.speed = minSpeed;
    }

    public void RemoveSlow(float slowSpeed)
    {
        if (myAgent.speed + slowSpeed <= _defaultSpeed)
            myAgent.speed += slowSpeed;
        else
            myAgent.speed = _defaultSpeed;
    }

    private void OnStatsChanged()
    {
        _damage = _stats.Damage;
        _attackCooldown = _stats.AttackCooldown;
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

    private IEnumerator FindTargetCoroutine()
    {
        var delay = new WaitForSeconds(3f);

        while (true)
        {
            FindNewTarget();

            yield return delay;
        }
    }

    private void FindNewTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _agrRange);

        var enemyGameObject = FindNearestTarget(hitColliders);

        if (enemyGameObject != null)
            _target = enemyGameObject.GetComponent<Health>();
    }

    private IEnumerator Attack(Health targetHealth)
    {
        yield return new WaitForSeconds(0.2f);

        if (_health.IsAlive)
            targetHealth.TakeDamage(_damage);
    }
}