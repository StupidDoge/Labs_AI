using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaIdleState : IdleState
{
    private Ninja _ninja;

    public NinjaIdleState(Entity entity, FiniteStateMachine stateMachine, string animationName, IdleStateData stateData, Ninja ninja) : base(entity, stateMachine, animationName, stateData)
    {
        _ninja = ninja;
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

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(_ninja.PlayerDetectedState);
        }
        else if (isIdleTimeOver)
            stateMachine.ChangeState(_ninja.MoveState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
