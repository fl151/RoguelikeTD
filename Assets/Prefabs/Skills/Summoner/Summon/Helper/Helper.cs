using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(HelperStats))]
public class Helper : MonoBehaviour
{
    [SerializeField] private DefaultHelpersStateMachine _stateMachine;

    private NavMeshAgent _myAgent;
    private Animator _animator;
    private EnemyHealth _enemy;
    private HelperStats _stats;
    
    public EnemyHealth Target => _enemy;
    public float AttackRange => _stats.AttackRange;
    public float AgrRange => _stats.AgrRange;
    public Animator Animator => _animator;
    public HelperStats Stats => _stats;
    public NavMeshAgent Agent => _myAgent;

    private void Awake()
    {
        _stats = GetComponent<HelperStats>();
        _myAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        _stateMachine.Init(this);
    }

    private void Update()
    {
        if(_enemy != null && _enemy.gameObject.activeSelf == false)
        {
            _enemy = null;
        }
    }

    public void SetTarget(EnemyHealth target)
    {
        _enemy = target;
    }
}