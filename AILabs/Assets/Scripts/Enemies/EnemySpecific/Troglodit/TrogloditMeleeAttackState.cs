using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrogloditMeleeAttackState : MeleeAttackState
{
    private Troglodit _troglodit;

    public TrogloditMeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animationName, Transform attackPosition, MeleeAttackStateData stateData, Troglodit troglodit) : base(entity, stateMachine, animationName, attackPosition, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
                stateMachine.ChangeState(_troglodit.PlayerDetectedState);
            else
                stateMachine.ChangeState(_troglodit.LookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
