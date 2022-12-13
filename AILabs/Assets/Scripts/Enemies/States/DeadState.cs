using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    protected DeadStateData stateData;
    protected bool isAnimationFinished;

    public DeadState(Entity entity, FiniteStateMachine stateMachine, string animationName, DeadStateData stateData) : base(entity, stateMachine, animationName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        entity.AnimToStateMachine.EnemyDeadState = this;
        isAnimationFinished = false;
        entity.SetVelocity(0f);
        entity.EnemyBoxCollider.enabled = false;
        entity.SetZeroGravity();
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

    public virtual void DeathAction()
    {
        entity.SoundController.PlayDeathSound();
    }

    public virtual void FinishDeath()
    {
        isAnimationFinished = true;
    }
}
