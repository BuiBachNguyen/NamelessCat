using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    Animator _animatator;

    public IdleState(Animator animatator)
    {
        this._animatator = animatator;
    }
    public void Enter()
    {
        if (_animatator == null) return;
        _animatator.SetBool("isStaying", true);
    }

    public void Execute()
    {
        //Debug.Log("Executing Idle State");
    }

    public void Exit()
    {
        if (_animatator == null) return;
        _animatator.SetBool("isStaying", false);
    }
}
