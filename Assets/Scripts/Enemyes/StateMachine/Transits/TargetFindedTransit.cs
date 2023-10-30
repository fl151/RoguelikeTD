public class TargetFindedTransit : Transit
{
    private Enemy _enemy;

    public TargetFindedTransit(IState currentState, IState targetState, Enemy enemy)
    {
        _currentState = currentState;
        _targetState = targetState;
        _enemy = enemy;
    }

    public override bool NeedTransit()
    {
        return _enemy.Target != null;
    }
}
