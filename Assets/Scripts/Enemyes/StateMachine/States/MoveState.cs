using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : IState
{
    private NavMeshAgent _agent;
    private Enemy _enemy;

    public MoveState(NavMeshAgent agent, Enemy enemy)
    {
        _agent = agent;
        _enemy = enemy;
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
