public class TargetLostHelperTransit : Transit
{
    private Helper _helper;

    public TargetLostHelperTransit(IState currentState, IState targetState, Helper helper)
    {
        _currentState = currentState;
        _targetState = targetState;
        _helper = helper;
    }

    public override bool NeedTransit()
    {
        return _helper.Target == null;
    }
}
