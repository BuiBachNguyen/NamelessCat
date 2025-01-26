using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleState : IState
{
    Animator _animatator;

    public TeleState(Animator animatator)
    {
        this._animatator = animatator;
    }

    public void Enter()
    {
        if (_animatator == null) return;

    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        if (_animatator == null) return;

    }
}
