using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueState : NPC_State
{
    protected NPCDialogueStateData dialogueStateData;

    public NPCDialogueState(NPC_Entity entity, NPC_StateMachine stateMachine, string animationName, NPCDialogueStateData dialogueStateData) : base(entity, stateMachine, animationName)
    {
        this.dialogueStateData = dialogueStateData;
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
