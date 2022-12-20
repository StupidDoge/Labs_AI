using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkIdleState : NPCIdleState
{
    private Monk _monk;

    public MonkIdleState(NPC_Entity entity, NPC_StateMachine stateMachine, string animationName, NPCIdleStateData idleStateData, Monk monk) : base(entity, stateMachine, animationName, idleStateData)
    {
        _monk = monk;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isIdleTimeOver)
            stateMachine.ChangeState(_monk.MoveState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
