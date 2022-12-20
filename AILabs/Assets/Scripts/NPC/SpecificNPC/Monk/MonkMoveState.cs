using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkMoveState : NPCMoveState
{
    private Monk _monk;

    private bool _dialogueStarted;

    public MonkMoveState(NPC_Entity entity, NPC_StateMachine stateMachine, string animationName, NPCMoveStateData moveStateData, Monk monk) : base(entity, stateMachine, animationName, moveStateData)
    {
        _monk = monk;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        _dialogueStarted = _monk.DialogueStarted;
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

        if (isDetectingWall || !isDetectingLedge)
        {
            _monk.IdleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(_monk.IdleState);
        }
        else if (_dialogueStarted)
            stateMachine.ChangeState(_monk.DialogueState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
