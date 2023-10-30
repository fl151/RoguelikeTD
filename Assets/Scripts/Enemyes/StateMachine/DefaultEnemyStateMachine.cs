using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DefaultEnemyStateMachine : MonoBehaviour
{
    private Enemy _enemy;

    private FindTargetState _findTargetState;
    private AttackState _attackState;
    private IdleState _idleState;
    private MoveState _moveState;

    private IState _firstState;
    private IState _currentState;

    private List<Transit> _transits = new List<Transit>();

    public void Init(Enemy enemy)
    {
        _enemy = enemy;

        _findTargetState = new FindTargetState(_enemy);
        _attackState = new AttackState(_enemy);
        _idleState = new IdleState();
        _moveState = new MoveState(_enemy);

        _firstState = _findTargetState;

        _transits.Add(new TargetLostTransit(_moveState, _findTargetState, _enemy));
        _transits.Add(new TargetLostTransit(_attackState, _findTargetState, _enemy));

        _transits.Add(new EnemyDieTransit(_moveState, _idleState, _enemy.Health));
        _transits.Add(new EnemyDieTransit(_attackState, _idleState, _enemy.Health));
        _transits.Add(new EnemyDieTransit(_findTargetState, _idleState, _enemy.Health));

        _transits.Add(new TargetFindedTransit(_findTargetState, _moveState, _enemy));
        _transits.Add(new RangeAttackTransit(_moveState, _attackState, _enemy));
        _transits.Add(new NoRangeAttackTransit(_attackState, _moveState, _enemy));  
    }

    private void OnEnable()
    {
        _currentState = _firstState;

        _currentState.Start();
    }

    private void Update()
    {
        foreach (var transit in _transits)
        {
            if (transit.CurrentState == _currentState && transit.NeedTransit())
            {
                _currentState.Stop();
                _currentState = transit.TargetState;
                _currentState.Start();
                return;
            }
        }

        _currentState.OnTick();
    }
}
