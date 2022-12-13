using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrogloditMoveState : MoveState
{
    private Troglodit _troglodit;

    public TrogloditMoveState(Entity entity, FiniteStateMachine stateMachine, string animationName, MoveStateData stateData, Troglodit troglodit) : base(entity, stateMachine, animationName, stateData)
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
        else if (isDetectingWall || !isDetectingLedge)
        {
            _troglodit.IdleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(_troglodit.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
