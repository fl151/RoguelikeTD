using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyStats))]
public class Enemy : MonoBehaviour
{
    private const float _attackRange = 1;
    private const float _agrRange = 100f;

    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _attackCooldown = 2f;

    private NavMeshAgent _myAgent;
    private Animator _animator;
    private Health _target;
    private float _cooldownTimer = 0f;

    private float _defaultSpeed;

    private EnemyStats _stats;
    private EnemyHealth _health;

    public Health Target => _target;

    private void Awake()
    {
        _stats = GetComponent<EnemyStats>();
        _health = GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _defaultSpeed = _myAgent.speed;

        StartCoroutine(FindTargetCoroutine());
    }

    private void Update()
    {
        if (_target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);

            if (_cooldownTimer <= 0f && distanceToTarget <= _attackRange)
            {
                _myAgent.isStopped = true;
                _animator.SetTrigger("isAttack");

                Health targetHealth = _target.GetComponent<Health>();

                if (targetHealth != null)
                {
                    StartCoroutine(Attack(targetHealth));
                }

                _cooldownTimer = _attackCooldown;
            }
            else
            {
                _myAgent.isStopped = false;
                _myAgent.destination = _target.transform.position;
                _animator.ResetTrigger("isAttack");
            }
        }
        else
        {
            FindNewTarget();
        }

        _cooldownTimer -= Time.deltaTime;
    }

    public void SetTarget(Health target)
    {
        _target = target;
    }

    public void MakeSlow(float slowCoefficient)
    {
        _myAgent.speed = _defaultSpeed * (1 - slowCoefficient);
    }

    public void MakeNormalSpeed()
    {
        _myAgent.speed = _defaultSpeed;
    }

    public void AddSlow(float slowSpeed)
    {
        float minSpeed = 0.2f * _defaultSpeed;

        if(_myAgent.speed - slowSpeed >= minSpeed)
            _myAgent.speed -= slowSpeed;
        else
            _myAgent.speed = minSpeed;
    }

    public void RemoveSlow(float slowSpeed)
    {
        if (_myAgent.speed + slowSpeed <= _defaultSpeed)
            _myAgent.speed += slowSpeed;
        else
            _myAgent.speed = _defaultSpeed;
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