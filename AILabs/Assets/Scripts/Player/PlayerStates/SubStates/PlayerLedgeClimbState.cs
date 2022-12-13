using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{
    private Vector2 _detectedPosition;
    private Vector2 _cornerPosition;
    private Vector2 _startPosition;
    private Vector2 _stopPosition;

    private bool _isHanging;
    private bool _isClimbing;

    private int _xInput;
    private int _yInput;

    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        player.PlayerAnimator.SetBool("climbLedge", false);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        _isHanging = true;
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityZero();
        player.transform.position = _detectedPosition;
        _cornerPosition = player.DetermineCornerPosition();

        _startPosition.Set(_cornerPosition.x - (player.FacingDirection * playerData.StartOffset.x), _cornerPosition.y - playerData.StartOffset.y);
        _stopPosition.Set(_cornerPosition.x + (player.FacingDirection * playerData.StopOffset.x), _cornerPosition.y + playerData.StopOffset.y);

        player.transform.position = _startPosition;
    }

    public override void Exit()
    {
        base.Exit();

        _isHanging = false;

        if (_isClimbing)
        {
            player.transform.position = _stopPosition;
            _isClimbing = false;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
            stateMachine.ChangeState(player.IdleState);
        else
        {
            _xInput = player.InputHandler.NormalizedInputX;
            _yInput = player.InputHandler.NormalizedInputY;

            player.SetVelocityZero();
            player.transform.position = _startPosition;

            if (_xInput == player.FacingDirection && _isHanging && !_isClimbing)
            {
                _isClimbing = true;
                player.PlayerAnimator.SetBool("climbLedge", true);
            }
            else if (_yInput == -1 && _isHanging && !_isClimbing)
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }

    public void SetDetectedPosition(Vector2 position) => _detectedPosition = position;
}
