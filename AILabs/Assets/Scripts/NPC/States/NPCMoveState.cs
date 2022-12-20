using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoveState : NPC_State
{
    protected NPCMoveStateData moveStateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;

    public NPCMoveState(NPC_Entity entity, NPC_StateMachine stateMachine, string animationName, NPCMoveStateData moveStateData) : base(entity, stateMachine, animationName)
    {
        this.moveStateData = moveStateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(moveStateData.MovementSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
