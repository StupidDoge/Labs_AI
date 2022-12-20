using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMeleeAttackState : MeleeAttackState
{
    private Ninja _ninja;

    public NinjaMeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animationName, Transform attackPosition, MeleeAttackStateData stateData, Ninja ninja) : base(entity, stateMachine, animationName, attackPosition, stateData)
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
                stateMachine.ChangeState(_ninja.PlayerDetectedState);
            else
                stateMachine.ChangeState(_ninja.LookForPlayerState);
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
