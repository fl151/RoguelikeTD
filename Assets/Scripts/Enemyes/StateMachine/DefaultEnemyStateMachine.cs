using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DefaultEnemyStateMachine : StateMachine
{
    private Enemy _enemy;

    public void Init(Enemy enemy)
    {
        _enemy = enemy;

        var findTargetState = new FindTargetState(_enemy);
        var attackState = new AttackState(_enemy);
        var idleState = new IdleState();
        var moveState = new MoveState(_enemy);

        _firstState = findTargetState;

        _transits.Add(new TargetLostTransit(moveState, findTargetState, _enemy));
        _transits.Add(new TargetLostTransit(attackState, findTargetState, _enemy));

        _transits.Add(new EnemyDieTransit(moveState, idleState, _enemy.Health));
        _transits.Add(new EnemyDieTransit(attackState, idleState, _enemy.Health));
        _transits.Add(new EnemyDieTransit(findTargetState, idleState, _enemy.Health));

        _transits.Add(new TargetFindedTransit(findTargetState, moveState, _enemy));
        _transits.Add(new RangeAttackTransit(moveState, attackState, _enemy));
        _transits.Add(new NoRangeAttackTransit(attackState, moveState, _enemy));  
    }
}
