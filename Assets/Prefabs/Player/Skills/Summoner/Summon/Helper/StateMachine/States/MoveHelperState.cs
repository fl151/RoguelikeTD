using UnityEngine.AI;

public class MoveHelperState : IState
{
    private readonly NavMeshAgent _agent;
    private readonly Helper _helper;

    public MoveHelperState(Helper helper)
    {
        _helper = helper;
        _agent = _helper.Agent;
    }

    public void Start()
    {
        _agent.isStopped = false;
    }

    public void OnTick()
    {
        _agent.destination = _helper.Target.transform.position;
    }

    public void Stop()
    {
        _agent.isStopped = true;
    }
}
