public abstract class Transit
{
    protected IState _currentState;
    protected IState _targetState;

    public IState CurrentState;
    public IState TargetState;

    public abstract bool NeedTransit();
}
