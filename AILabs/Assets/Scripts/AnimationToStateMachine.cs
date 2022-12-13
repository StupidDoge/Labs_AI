using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
    public AttackState EnemyAttackState;
    public DeadState EnemyDeadState;

    private void TriggerAttack()
    {
        EnemyAttackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        EnemyAttackState.FinishAttack();
    }

    private void DeathAction()
    {
        EnemyDeadState.DeathAction();
    }

    private void FinishDeath()
    {
        EnemyDeadState.FinishDeath();
    }
}
