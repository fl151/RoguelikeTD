public class EnemyDieTransit : Transit
{
    private EnemyHealth _enemy;

    public EnemyDieTransit(IState currentState, IState targetState, EnemyHealth enemy)
    {
        _currentState = currentState;
        _targetState = targetState;
        _enemy = enemy;
    }

    public override bool NeedTransit()
    {
        return _enemy.IsAlive == false;
    }
}
