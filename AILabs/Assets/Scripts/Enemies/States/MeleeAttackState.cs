using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    protected MeleeAttackStateData stateData;

    protected AttackDetails attackDetails;

    public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animationName, Transform attackPosition, MeleeAttackStateData stateData) : base(entity, stateMachine, animationName, attackPosition)
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

        attackDetails.damageAmount = stateData.Damage;
        attackDetails.position = entity.AliveGameObject.transform.position;
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.AttackRadius, stateData.PlayerLayer);

        foreach (Collider2D collider in detectedObjects)
        {
            /*collider.transform.SendMessage("Damage", attackDetails);*/
            Debug.Log("Damage " + attackDetails.damageAmount + " HP to " + collider.gameObject.name);
        }
    }
}
