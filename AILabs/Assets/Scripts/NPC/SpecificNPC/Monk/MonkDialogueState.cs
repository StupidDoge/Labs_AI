using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkDialogueState : NPCDialogueState
{
    private Monk _monk;

    private bool _dialogueStarted;

    public MonkDialogueState(NPC_Entity entity, NPC_StateMachine stateMachine, string animationName, NPCDialogueStateData dialogueStateData, Monk monk) : base(entity, stateMachine, animationName, dialogueStateData)
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
        _monk.SetVelocity(0f);
        _monk.StartDialogue();
    }

    public override void Exit()
    {
        base.Exit();
        _monk.DisableDialogueCollider();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!_dialogueStarted)
            _monk.StateMachine.ChangeState(_monk.MoveState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
