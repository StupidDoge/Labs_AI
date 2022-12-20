using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMoveState : MoveState
{
    private Ninja _ninja;

    public NinjaMoveState(Entity entity, FiniteStateMachine stateMachine, string animationName, MoveStateData stateData, Ninja ninja) : base(entity, stateMachine, animationName, stateData)
    {
        _ninja = ninja;
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

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(_ninja.PlayerDetectedState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            _ninja.IdleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(_ninja.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
