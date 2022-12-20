using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_State
{
    protected NPC_StateMachine stateMachine;
    protected NPC_Entity entity;

    protected float startTime;

    protected string animationName;

    public NPC_State(NPC_Entity entity, NPC_StateMachine stateMachine, string animationName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animationName = animationName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.NpcAnimator.SetBool(animationName, true);
        DoChecks();
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void Exit()
    {
        entity.NpcAnimator.SetBool(animationName, false);
    }

    public virtual void DoChecks()
    {

    }
}
