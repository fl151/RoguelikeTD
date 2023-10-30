using UnityEngine;

public class RangeAttackTransit : Transit
{
    private Enemy _enemy;

    public RangeAttackTransit(IState currentState, IState targetState, Enemy enemy)
    {
        _currentState = currentState;
        _targetState = targetState;
        _enemy = enemy;
    }

    public override bool NeedTransit()
    {
        if (_enemy.Target == null) return false;

        float distanceToTarget = Vector3.Distance(_enemy.transform.position, _enemy.Target.transform.position);

        return distanceToTarget <= _enemy.AttackRange;
    }
}
