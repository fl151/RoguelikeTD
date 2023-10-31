using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected IState _firstState;
    protected IState _currentState;

    protected List<Transit> _transits = new List<Transit>();

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
