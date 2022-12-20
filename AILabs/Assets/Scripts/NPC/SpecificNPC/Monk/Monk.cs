using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk : NPC_Entity
{
    public static Action<TextAsset> OnDialogueStarted;

    public MonkIdleState IdleState { get; private set; }
    public MonkMoveState MoveState { get; private set; }
    public MonkDialogueState DialogueState { get; private set; }

    [SerializeField] private NPCMoveStateData _moveStateData;
    [SerializeField] private NPCIdleStateData _idleStateData;
    [SerializeField] private NPCDialogueStateData _dialogueStateData;

    private TextAsset _currentTextAsset;

    public override void Start()
    {
        base.Start();

        MoveState = new MonkMoveState(this, StateMachine, "move", _moveStateData, this);
        IdleState = new MonkIdleState(this, StateMachine, "idle", _idleStateData, this);
        DialogueState = new MonkDialogueState(this, StateMachine, "idle", _dialogueStateData, this);

        _currentTextAsset = _dialogueStateData.StartDialogue;

        StateMachine.Init(MoveState);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        LevelManager.OnAllNinjasDefeated += ChangeDialogue;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        LevelManager.OnAllNinjasDefeated -= ChangeDialogue;
    }

    private void ChangeDialogue()
    {
        _currentTextAsset = _dialogueStateData.EndDialogue;
        Debug.Log("change");
    }

    public void StartDialogue()
    {
        OnDialogueStarted?.Invoke(_currentTextAsset);
    }
}
