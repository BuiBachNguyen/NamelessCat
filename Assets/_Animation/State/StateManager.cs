using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    [SerializeField] IState _currentState;
    void Update()
    {
        if (_currentState != null)
            _currentState.Execute();
    }

    public void ChangeState(IState state)
    {
        if (_currentState != null && _currentState == state) return;

        if (_currentState != null)
            _currentState.Exit();

        _currentState = state;

        if (_currentState != null)
            _currentState.Enter();
    }
}
