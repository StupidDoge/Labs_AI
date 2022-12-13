using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troglodit : Entity
{
    public TrogloditIdleState IdleState { get; private set; }
    public TrogloditMoveState MoveState { get; private set; }
    public TrogloditPlayerDetectedState PlayerDetectedState { get; private set; }
    public TrogloditChargeState ChargeState { get; private set; }
    public TrogloditLookForPlayerState LookForPlayerState { get; private set; }
    public TrogloditMeleeAttackState MeleeAttackState { get; private set; }
    public TrogloditDeadState DeadState { get; private set; }

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

        MoveState = new TrogloditMoveState(this, StateMachine, "move", _moveStateData, this);
        IdleState = new TrogloditIdleState(this, StateMachine, "idle", _idleStateData, this);
        PlayerDetectedState = new TrogloditPlayerDetectedState(this, StateMachine, "playerDetected", _playerDetectedStateData, this);
        ChargeState = new TrogloditChargeState(this, StateMachine, "charge", _chargeStateData, this);
        LookForPlayerState = new TrogloditLookForPlayerState(this, StateMachine, "lookForPlayer", _lookForPlayerStateData, this);
        MeleeAttackState = new TrogloditMeleeAttackState(this, StateMachine, "meleeAttack", _meleeAttackPosition, _meleeAttackStateData, this);
        DeadState = new TrogloditDeadState(this, StateMachine, "dead", _deadStateData, this);

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
