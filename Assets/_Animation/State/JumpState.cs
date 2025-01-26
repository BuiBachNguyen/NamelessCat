using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    Animator _animatator;

    public JumpState(Animator animatator)
    {
        this._animatator = animatator;
    }

    public void Enter()
    {
        if (_animatator == null) return;
        _animatator.SetBool("isJumping", true);
    }

    public void Execute()
    {
        Debug.Log("ex jump");
    }

    public void Exit()
    {
        if(_animatator == null) return;
        _animatator.SetBool("isJumping",false);
    }

}
