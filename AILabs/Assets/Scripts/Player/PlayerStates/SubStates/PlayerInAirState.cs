using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private int _xInput;
    private bool _grabInput;
    private bool _isGrounded;
    private bool _jumpInput;
    private bool _jumpInputStop;
    private bool _coyoteTime;
    private bool _wallJumpCoyoteTime;
    private bool _isJumping;

    private float _startWallJumpCoyoteTime;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        _isGrounded = player.CheckIfGrounded();
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

        CheckCoyoteTime();

        _xInput = player.InputHandler.NormalizedInputX;
        _jumpInput = player.InputHandler.JumpInput;
        _jumpInputStop = player.InputHandler.JumpInputStop;
        _grabInput = player.InputHandler.GrabInput;

        CheckJumpMultiplier();

        if (_isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else if (_jumpInput && player.JumpState.CanJump())
        {
            _coyoteTime = false;
            stateMachine.ChangeState(player.JumpState);
        }
        else
        {
            player.CheckIfShouldFlip(_xInput);
            player.SetVelocityX(playerData.MovementVelocity * _xInput);

            player.PlayerAnimator.SetFloat("yVelocity", player.CurrentVelocity.y);
            player.PlayerAnimator.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));
        }
    }

    private void CheckJumpMultiplier()
    {
        if (_isJumping)
        {
            if (_jumpInputStop)
            {
                player.SetVelocityY(player.CurrentVelocity.y * playerData.JumpHeightMultiplier);
                _isJumping = false;
            }
            else if (player.CurrentVelocity.y <= 0f)
                _isJumping = false;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckCoyoteTime()
    {
        if (_coyoteTime && Time.time > startTime + playerData.CoyoteTime)
        {
            _coyoteTime = false;
            player.JumpState.DecreaseAmountOfJumpsLeft();
        }
    }

    public void StartCoyoteTime() => _coyoteTime = true;

    public void SetIsJumping() => _isJumping = true;
}
