using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueState : PlayerGroundedState
{
    public static Action<bool> OnDialogueStarted;

    private bool _dialogueStarted;

    public PlayerDialogueState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        _dialogueStarted = player.DialogueStarted;
    }

    public override void Enter()
    {
        base.Enter();
        OnDialogueStarted?.Invoke(true);
    }

    public override void Exit()
    {
        base.Exit();
        OnDialogueStarted?.Invoke(false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!_dialogueStarted)
            player.StateMachine.ChangeState(player.IdleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
