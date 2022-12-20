using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdleState : NPC_State
{
    protected NPCIdleStateData idleStateData;

    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;

    protected float idleTime;

    public NPCIdleState(NPC_Entity entity, NPC_StateMachine stateMachine, string animationName, NPCIdleStateData idleStateData) : base(entity, stateMachine, animationName)
    {
        this.idleStateData = idleStateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

    public void SetRandomIdleTime() => idleTime = Random.Range(idleStateData.MinIdleTime, idleStateData.MaxIdleTime);
}
