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
    [SerializeField] private NPCDialogueStateData _dialogueStateData;

    public override void Start()
    {
        base.Start();

        MoveState = new MonkMoveState(this, StateMachine, "move", _moveStateData, this);
        IdleState = new MonkIdleState(this, StateMachine, "idle", _idleStateData, this);
        DialogueState = new MonkDialogueState(this, StateMachine, "idle", _dialogueStateData, this);

        StateMachine.Init(MoveState);
    }
}
