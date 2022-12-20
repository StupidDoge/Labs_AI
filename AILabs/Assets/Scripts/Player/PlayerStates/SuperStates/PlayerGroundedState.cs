using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;

    private bool _jumpInput;
    private bool _grabInput;
    private bool _interactionInput;
    private bool _isGrounded;
    private bool _isTouchingWall;
    private bool _dialogueIsStarted;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        _isGrounded = player.CheckIfGrounded();
        _isTouchingWall = player.CheckIfTouchingWall();
        _dialogueIsStarted = player.DialogueStarted;
    }

    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumpsLeft();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormalizedInputX;
        _jumpInput = player.InputHandler.JumpInput;
        _grabInput = player.InputHandler.GrabInput;
        _interactionInput = player.InputHandler.InteractionInput;
        
        if (player.InputHandler.AttackInputs[(int)CombatInputs.primary] && xInput == 0 && !_dialogueIsStarted)
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if (player.InputHandler.AttackInputs[(int)CombatInputs.secondary] && !_dialogueIsStarted)
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }
        else if (_jumpInput && player.JumpState.CanJump() && !_dialogueIsStarted)
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (_interactionInput && player.CanStartDialogue)
        {
            stateMachine.ChangeState(player.DialogueState);
        }
        else if (!_isGrounded)
        {
            player.InAirState.StartCoyoteTime();
            stateMachine.ChangeState(player.InAirState);
        }
        else if (_isTouchingWall && _grabInput)
            stateMachine.ChangeState(player.WallGrabState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
