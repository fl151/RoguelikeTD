using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(HelperStats))]
public class HelperMovement : MonoBehaviour
{
    private NavMeshAgent _myAgent;
    private Animator _animator;
    private EnemyMovement _enemy;
    private HelperStats _stats;
    
    private float _cooldownTimer = 0f;

    private float _agrRange = 10f;

    private void Awake()
    {
        _stats = GetComponent<HelperStats>();
    }

    private void Start()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_enemy == null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _agrRange);

            var enemyGameObject = FindNearestEnemy(hitColliders);

            if (enemyGameObject != null)
                _enemy = enemyGameObject.GetComponent<EnemyMovement>();
        }
        else
        {
            float distanceToPlayer = Vector3.Distance(transform.position, _enemy.transform.position);

            if (_cooldownTimer <= 0f && distanceToPlayer <= _stats.AttackRange)
            {
                _myAgent.isStopped = true;
                _animator.SetTrigger("isAttack");

                EnemyHealth enemyHealth = _enemy.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(_stats.Damage);
                }

                _myAgent.isStopped = false;
                _cooldownTimer = 1 / _stats.AttackSpeed;
            }
            else
            {
                _myAgent.isStopped = false;
                _myAgent.destination = _enemy.transform.position;
                _animator.ResetTrigger("isAttack");
            }

            _cooldownTimer -= Time.deltaTime;
        }
    }

    private GameObject FindNearestEnemy(Collider[] colliders)
    {
        GameObject nearestEnemy = null;
        float nearestDistance = float.MaxValue;

        foreach (Collider collider in colliders)
        {
            EnemyHealth enemy = collider.GetComponent<EnemyHealth>();

            if (enemy != null && collider.gameObject.activeSelf)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);

                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = collider.gameObject;
                }
            }
        }

        return nearestEnemy;
    }
}