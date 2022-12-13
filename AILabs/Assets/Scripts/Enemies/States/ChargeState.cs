using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
    protected ChargeStateData stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAction;

    public ChargeState(Entity entity, FiniteStateMachine stateMachine, string animationName, ChargeStateData stateData) : base(entity, stateMachine, animationName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();

        isChargeTimeOver = false;
        entity.SetVelocity(stateData.ChargeSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + stateData.ChargeTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
