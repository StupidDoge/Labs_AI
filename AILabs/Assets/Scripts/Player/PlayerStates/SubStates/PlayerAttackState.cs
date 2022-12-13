using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapon _weapon;

    private float _velocity;
    private bool _setVelocity;
    private bool _checkShouldFlip;
    private int _xInput;

    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _setVelocity = false;
        _weapon.EnterWeapon();
    }

    public override void Exit()
    {
        base.Exit();

        _weapon.ExitWeapon();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        _xInput = player.InputHandler.NormalizedInputX;

        if (_checkShouldFlip)
            player.CheckIfShouldFlip(_xInput);

        if (_setVelocity)
            player.SetVelocityX(_velocity * player.FacingDirection);
    }

    public void SetWeapon(Weapon weapon)
    {
        _weapon = weapon;
        weapon.InitWeapon(this);
    }

    public void SetPlayerVelocity(float velocity)
    {
        player.SetVelocityX(velocity * player.FacingDirection);

        _velocity = velocity;
        _setVelocity = true;
    }

    public void SetFlipCheck(bool value) => _checkShouldFlip = value;

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }
}
