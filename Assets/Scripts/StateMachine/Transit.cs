public abstract class Transit
{
    protected IState _currentState;
    protected IState _targetState;

    public IState CurrentState => _currentState;
    public IState TargetState => _targetState;

    public abstract bool NeedTransit();
}
