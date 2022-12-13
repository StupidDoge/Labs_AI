using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    public State CurrentState { get; private set; }

    public void Init(State state)
    {
        CurrentState = state;
        CurrentState.Enter();
    }

    public void ChangeState(State state)
    {
        CurrentState.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }
}
