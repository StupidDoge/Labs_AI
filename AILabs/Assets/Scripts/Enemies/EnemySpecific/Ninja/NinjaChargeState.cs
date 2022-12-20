using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaChargeState : ChargeState
{
    private Ninja _ninja;

    public NinjaChargeState(Entity entity, FiniteStateMachine stateMachine, string animationName, ChargeStateData stateData, Ninja ninja) : base(entity, stateMachine, animationName, stateData)
    {
        _ninja = ninja;
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
            stateMachine.ChangeState(_ninja.MeleeAttackState);
        else if (!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(_ninja.LookForPlayerState);
        }
        else if (isChargeTimeOver)
        {
            if (isPlayerInMinAgroRange)
                stateMachine.ChangeState(_ninja.PlayerDetectedState);
            else
                stateMachine.ChangeState(_ninja.LookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
