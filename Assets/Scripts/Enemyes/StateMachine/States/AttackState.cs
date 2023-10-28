using UnityEngine;

public class AttackState : IState
{
    private const float _attackDelayTime = 0.2f;
    private float _attackDelay;
    private float _cooldownTimer = 0;
    private EnemyStats _stats;
    private Animator _animator;
    private Health _target;

    public AttackState(EnemyStats stats, Animator animator, Health target)
    {
        _stats = stats;
        _animator = animator;
        _target = target;
    }

    public void Start()
    {
        _attackDelay = _attackDelayTime;
    }

    public void OnTick()
    {
        if (_cooldownTimer <= 0)
        {
            _animator.SetTrigger("isAttack");

            if (_attackDelay <= 0)
            {
                _target.TakeDamage(_stats.Damage);
                _attackDelay = _attackDelayTime;
            }

            _cooldownTimer = _stats.AttackCooldown;
        }

        _attackDelay -= Time.deltaTime;
        _cooldownTimer -= Time.deltaTime;
    }

    public void Stop(){}
}
