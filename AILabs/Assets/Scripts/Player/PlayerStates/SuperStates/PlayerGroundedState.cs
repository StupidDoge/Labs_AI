using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;

    private bool _jumpInput;
    private bool _grabInput;
    private bool _isGrounded;
    private bool _isTouchingWall;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        _isGrounded = player.CheckIfGrounded();
        _isTouchingWall = player.CheckIfTouchingWall();
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
        
        if (player.InputHandler.AttackInputs[(int)CombatInputs.primary] && xInput == 0)
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if (player.InputHandler.AttackInputs[(int)CombatInputs.secondary])
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }
        else if (_jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
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
