using UnityEngine;

public class NoRangeAttackHelperTransit : Transit
{
    private Helper _helper;

    public NoRangeAttackHelperTransit(IState currentState, IState targetState, Helper helper)
    {
        _currentState = currentState;
        _targetState = targetState;
        _helper = helper;
    }

    public override bool NeedTransit()
    {
        if (_helper.Target == null) return false;

        float distanceToTarget = Vector3.Distance(_helper.transform.position, _helper.Target.transform.position);

        return distanceToTarget > _helper.AttackRange;
    }
}
