using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrogloditChargeState : ChargeState
{
    private Troglodit _troglodit;

    public TrogloditChargeState(Entity entity, FiniteStateMachine stateMachine, string animationName, ChargeStateData stateData, Troglodit troglodit) : base(entity, stateMachine, animationName, stateData)
    {
        _troglodit = troglodit;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

        if (performCloseRangeAction)
            stateMachine.ChangeState(_troglodit.MeleeAttackState);
        else if (!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(_troglodit.LookForPlayerState);
        }
        else if (isChargeTimeOver)
        {
            if (isPlayerInMinAgroRange)
                stateMachine.ChangeState(_troglodit.PlayerDetectedState);
            else
                stateMachine.ChangeState(_troglodit.LookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
