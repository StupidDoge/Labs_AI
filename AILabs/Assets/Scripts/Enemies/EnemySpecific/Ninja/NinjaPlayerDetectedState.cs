using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaPlayerDetectedState : PlayerDetectedState
{
    private Ninja _ninja;

    public NinjaPlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animationName, PlayerDetectedStateData stateData, Ninja ninja) : base(entity, stateMachine, animationName, stateData)
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

        if (performCloseRangeAction)
            stateMachine.ChangeState(_ninja.MeleeAttackState);
        else if (performLongRangeAction)
            stateMachine.ChangeState(_ninja.ChargeState);
        else if (!isPlayerInMaxAgroRange)
            stateMachine.ChangeState(_ninja.LookForPlayerState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
