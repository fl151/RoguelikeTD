using UnityEngine;

[RequireComponent(typeof(Helper))]
public class DefaultHelpersStateMachine : StateMachine
{
    private Helper _helper;

    public void Init(Helper helper)
    {
        _helper = helper;

        var findTargetState = new FindTargetHelperState(_helper);
        var attackState = new AttackHelperState(_helper);
        var moveState = new MoveHelperState(_helper);

        _firstState = findTargetState;

        _transits.Add(new TargetLostHelperTransit(moveState, findTargetState, _helper));
        _transits.Add(new TargetLostHelperTransit(attackState, findTargetState, _helper));

        _transits.Add(new TargetFindedHelperTransit(findTargetState, moveState, _helper));
        _transits.Add(new RangeAttackHelperTransit(moveState, attackState, _helper));
        _transits.Add(new NoRangeAttackHelperTransit(attackState, moveState, _helper));
    }

    private void OnEnable()
    {
        _currentState = _firstState;

        _currentState.Start();
    }
}
