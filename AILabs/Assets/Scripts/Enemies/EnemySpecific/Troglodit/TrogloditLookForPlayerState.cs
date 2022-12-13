using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrogloditLookForPlayerState : LookForPlayerState
{
    private Troglodit _troglodit;

    public TrogloditLookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animationName, LookForPlayerStateData stateData, Troglodit troglodit) : base(entity, stateMachine, animationName, stateData)
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange)
            stateMachine.ChangeState(_troglodit.PlayerDetectedState);
        else if (isAllTurnsTimeDone)
            stateMachine.ChangeState(_troglodit.MoveState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
