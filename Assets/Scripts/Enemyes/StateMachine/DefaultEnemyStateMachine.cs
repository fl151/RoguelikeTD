using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyStateMachine : MonoBehaviour
{
    private IState _currentState;
    private List<Transit> _transits;

    private void Awake()
    {
        
    }

    private void Update()
    {
        _currentState.OnTick();

        foreach (var transit in _transits)
        {
            if (transit.NeedTransit())
            {
                _currentState.Stop();
                _currentState = transit.TargetState;
                _currentState.Start();
                return;
            }
        }
    }
}
