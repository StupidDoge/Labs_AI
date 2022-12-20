using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaLookForPlayerState : LookForPlayerState
{
    private Ninja _ninja;

    public NinjaLookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animationName, LookForPlayerStateData stateData, Ninja ninja) : base(entity, stateMachine, animationName, stateData)
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange)
            stateMachine.ChangeState(_ninja.PlayerDetectedState);
        else if (isAllTurnsTimeDone)
            stateMachine.ChangeState(_ninja.MoveState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
