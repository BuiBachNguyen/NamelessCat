using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState
{
    Animator _animatator;

    public RunState(Animator animatator)
    {
        this._animatator = animatator;
    }

    public void Enter()
    {
        if (_animatator == null) return;
        _animatator.SetBool("isRunning", true);
    }

    public void Execute()
    {
        Debug.Log("ex Running");
    }

    public void Exit()
    {
        if (_animatator == null) return;
        _animatator.SetBool("isRunning", false);
    }
}
