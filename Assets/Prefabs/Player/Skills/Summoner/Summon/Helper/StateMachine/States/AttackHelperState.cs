using UnityEngine;

public class AttackHelperState : IState
{
    private readonly HelperStats _stats;
    private readonly Animator _animator;
    private readonly Helper _helper;

    private const float _attackDelayTime = 0.4f;
    private float _attackDelay;
    private float _cooldownTimer = 0;

    public AttackHelperState(Helper helper)
    {
        _helper = helper;
        _stats = _helper.Stats;
        _animator = _helper.Animator;
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
                _helper.Target.TakeDamage(_stats.Damage);
                _attackDelay = _attackDelayTime;
                _cooldownTimer = 1 / _stats.AttackSpeed;
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
