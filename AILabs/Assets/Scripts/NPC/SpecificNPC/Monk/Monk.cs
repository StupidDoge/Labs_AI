using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk : NPC_Entity
{
    public MonkIdleState IdleState { get; private set; }
    public MonkMoveState MoveState { get; private set; }
    public MonkDialogueState DialogueState { get; private set; }

    [SerializeField] private NPCMoveStateData _moveStateData;
    [SerializeField] private NPCIdleStateData _idleStateData;

    public override void Start()
    {
        base.Start();

        MoveState = new MonkMoveState(this, StateMachine, "move", _moveStateData, this);
        IdleState = new MonkIdleState(this, StateMachine, "idle", _idleStateData, this);

        StateMachine.Init(MoveState);
    }
}
