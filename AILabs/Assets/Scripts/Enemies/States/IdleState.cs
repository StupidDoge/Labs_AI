using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected IdleStateData stateData;

    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;
    protected bool isPlayerInMinAgroRange;
    protected bool isDead;

    protected float idleTime;

    public IdleState(Entity entity, FiniteStateMachine stateMachine, string animationName, IdleStateData stateData) : base(entity, stateMachine, animationName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isDead = entity.IsDead;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0f);
        isIdleTimeOver = false;
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetFlipAfterIdle(bool flip) => flipAfterIdle = flip;

    public void SetRandomIdleTime() => idleTime = Random.Range(stateData.MinIdleTime, stateData.MaxIdleTime);
}
