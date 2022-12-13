using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State
{
    protected PlayerDetectedStateData stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool performCloseRangeAction;
    protected bool performLongRangeAction;

    public PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animationName, PlayerDetectedStateData stateData) : base(entity, stateMachine, animationName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();

        performLongRangeAction = false;
        entity.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + stateData.LongRangeActionTime)
            performLongRangeAction = true;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
