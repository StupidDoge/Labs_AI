using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrogloditIdleState : IdleState
{
    private Troglodit _troglodit;

    public TrogloditIdleState(Entity entity, FiniteStateMachine stateMachine, string animationName, IdleStateData stateData, Troglodit troglodit) : base(entity, stateMachine, animationName, stateData)
    {
        _troglodit = troglodit;
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
            stateMachine.ChangeState(_troglodit.PlayerDetectedState);
        }
        else if (isIdleTimeOver)
            stateMachine.ChangeState(_troglodit.MoveState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
