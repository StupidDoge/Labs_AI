using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkDialogueState : NPCDialogueState
{
    private Monk _monk;

    public MonkDialogueState(NPC_Entity entity, NPC_StateMachine stateMachine, string animationName, NPCDialogueStateData dialogueStateData, Monk monk) : base(entity, stateMachine, animationName, dialogueStateData)
    {
        _monk = monk;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        _monk.SetVelocity(0f);
        Debug.Log("Monk In Dialogue");
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
