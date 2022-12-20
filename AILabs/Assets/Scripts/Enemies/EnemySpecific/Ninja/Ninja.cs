using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Entity
{
    public NinjaIdleState IdleState { get; private set; }
    public NinjaMoveState MoveState { get; private set; }
    public NinjaPlayerDetectedState PlayerDetectedState { get; private set; }
    public NinjaChargeState ChargeState { get; private set; }
    public NinjaLookForPlayerState LookForPlayerState { get; private set; }
    public NinjaMeleeAttackState MeleeAttackState { get; private set; }
    public NinjaDeadState DeadState { get; private set; }

    [SerializeField] private MoveStateData _moveStateData;
    [SerializeField] private IdleStateData _idleStateData;
    [SerializeField] private PlayerDetectedStateData _playerDetectedStateData;
    [SerializeField] private ChargeStateData _chargeStateData;
    [SerializeField] private LookForPlayerStateData _lookForPlayerStateData;
    [SerializeField] private MeleeAttackStateData _meleeAttackStateData;
    [SerializeField] private DeadStateData _deadStateData;

    [SerializeField] private Transform _meleeAttackPosition;

    public override void Start()
    {
        base.Start();

        MoveState = new NinjaMoveState(this, StateMachine, "move", _moveStateData, this);
        IdleState = new NinjaIdleState(this, StateMachine, "idle", _idleStateData, this);
        PlayerDetectedState = new NinjaPlayerDetectedState(this, StateMachine, "playerDetected", _playerDetectedStateData, this);
        ChargeState = new NinjaChargeState(this, StateMachine, "charge", _chargeStateData, this);
        LookForPlayerState = new NinjaLookForPlayerState(this, StateMachine, "lookForPlayer", _lookForPlayerStateData, this);
        MeleeAttackState = new NinjaMeleeAttackState(this, StateMachine, "meleeAttack", _meleeAttackPosition, _meleeAttackStateData, this);
        DeadState = new NinjaDeadState(this, StateMachine, "dead", _deadStateData, this);

        StateMachine.Init(MoveState);
    }

    public override void Damage(float damage)
    {
        base.Damage(damage);

        if (IsDead)
            StateMachine.ChangeState(DeadState);
    }

    /*public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(_meleeAttackPosition.position, _meleeAttackStateData.AttackRadius);
    }*/
}
