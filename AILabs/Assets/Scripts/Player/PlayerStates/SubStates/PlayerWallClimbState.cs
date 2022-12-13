using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallClimbState : PlayerTouchingWallState
{
    public PlayerWallClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            player.SetVelocityY(playerData.WallClimbVelocity);

            if (yInput != 1 && !isExitingState)
                stateMachine.ChangeState(player.WallGrabState);
        }
    }
}
