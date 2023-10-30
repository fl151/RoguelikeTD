using UnityEngine;

public class AttackState : IState
{
    private const float _attackDelayTime = 0.2f;
    private float _attackDelay;
    private float _cooldownTimer = 0;
    private EnemyStats _stats;
    private Animator _animator;
    private Enemy _enemy;

    public AttackState(Enemy enemy)
    {
        _enemy = enemy;
        _stats = _enemy.Stats;
        _animator = _enemy.Animator;
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
                _enemy.Target.TakeDamage(_stats.Damage);
                _attackDelay = _attackDelayTime;
                _cooldownTimer = _stats.AttackCooldown;
            }  
        }

        _attackDelay -= Time.deltaTime;
        _cooldownTimer -= Time.deltaTime;
    }

    public void Stop()
    {
        _animator.ResetTrigger("isAttack");
    }
}
