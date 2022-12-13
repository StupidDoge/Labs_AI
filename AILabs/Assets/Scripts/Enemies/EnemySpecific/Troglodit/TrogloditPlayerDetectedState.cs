using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrogloditPlayerDetectedState : PlayerDetectedState
{
    private Troglodit _troglodit;

    public TrogloditPlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animationName, PlayerDetectedStateData stateData, Troglodit troglodit) : base(entity, stateMachine, animationName, stateData)
    {
        _troglodit = troglodit;
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

        if (performCloseRangeAction)
            stateMachine.ChangeState(_troglodit.MeleeAttackState);
        else if (performLongRangeAction)
            stateMachine.ChangeState(_troglodit.ChargeState);
        else if (!isPlayerInMaxAgroRange)
            stateMachine.ChangeState(_troglodit.LookForPlayerState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
