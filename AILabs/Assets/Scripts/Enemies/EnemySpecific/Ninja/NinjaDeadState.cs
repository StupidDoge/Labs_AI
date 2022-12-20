using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaDeadState : DeadState
{
    private Ninja _ninja;

    public NinjaDeadState(Entity entity, FiniteStateMachine stateMachine, string animationName, DeadStateData stateData, Ninja ninja) : base(entity, stateMachine, animationName, stateData)
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

    public override void FinishDeath()
    {
        base.FinishDeath();
        entity.gameObject.SetActive(false);
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
