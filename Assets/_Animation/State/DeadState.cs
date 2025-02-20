using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    Animator _animatator;
    public DeadState(Animator animatator)
    {
        this._animatator = animatator;
    }

    public void Enter()
    {
        if (_animatator == null) return;
        _animatator.SetBool("isDead", true);
    }

    public void Execute()
    {
        //Debug.Log("ex Running");
    }

    public void Exit()
    {
        if (_animatator == null) return;
        _animatator.SetBool("isDead", false);

    }
}
