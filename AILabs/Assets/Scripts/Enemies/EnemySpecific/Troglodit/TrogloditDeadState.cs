using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrogloditDeadState : DeadState
{
    private Troglodit _troglodit;

    public TrogloditDeadState(Entity entity, FiniteStateMachine stateMachine, string animationName, DeadStateData stateData, Troglodit troglodit) : base(entity, stateMachine, animationName, stateData)
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
