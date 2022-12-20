using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_StateMachine
{
    public NPC_State CurrentState { get; private set; }

    public void Init(NPC_State state)
    {
        CurrentState = state;
        CurrentState.Enter();
    }

    public void ChangeState(NPC_State state)
    {
        CurrentState.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }
}
