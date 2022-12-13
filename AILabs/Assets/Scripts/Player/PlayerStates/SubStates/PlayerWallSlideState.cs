using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            player.SetVelocityY(-playerData.WallSlideVelocity);

            if (yInput == 0 && grabInput)
                stateMachine.ChangeState(player.WallGrabState);
            else if (yInput == 1 && grabInput)
                stateMachine.ChangeState(player.WallClimbState);
        }
    }
}
