using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerAbilityState
{
    private int _wallJumpDirection;

    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.InputHandler.UseJumpInput();
        player.JumpState.ResetAmountOfJumpsLeft();
        player.SetVelocity(playerData.wallJumpVelocity, playerData.wallJumpAngle, _wallJumpDirection);
        player.CheckIfShouldFlip(_wallJumpDirection);
        player.JumpState.DecreaseAmountOfJumpsLeft();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.PlayerAnimator.SetFloat("yVelocity", player.CurrentVelocity.y);
        player.PlayerAnimator.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));

        if (Time.time >= startTime + playerData.wallJumpTime)
        {
            isAbilityDone = true;
        }
    }

    public void DetermineWallJumpDirection(bool isTouchingWall)
    {
        if (isTouchingWall)
        {
            _wallJumpDirection = -player.FacingDirection;
        }
        else
        {
            _wallJumpDirection = player.FacingDirection;
        }
    }
}
