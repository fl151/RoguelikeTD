using UnityEngine.AI;

public class MoveState : IState
{
    private NavMeshAgent _agent;
    private Enemy _enemy;

    public MoveState(Enemy enemy)
    {
        _enemy = enemy;
        _agent = _enemy.Agent;
    }

    public void Start()
    {
        _agent.isStopped = false;
    }

    public void OnTick()
    {
        _agent.destination = _enemy.Target.transform.position;
    }

    public void Stop()
    {
        _agent.isStopped = true;
    }
}
