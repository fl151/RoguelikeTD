public class TargetLostTransit : Transit
{
    private Enemy _enemy;

    public TargetLostTransit(IState currentState, IState targetState, Enemy enemy)
    {
        _currentState = currentState;
        _targetState = targetState;
        _enemy = enemy;
    }

    public override bool NeedTransit()
    {
        return _enemy.Target == null;
    }
}
