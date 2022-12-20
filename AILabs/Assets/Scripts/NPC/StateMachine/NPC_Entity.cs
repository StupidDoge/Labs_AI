using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Entity : MonoBehaviour
{
    public NPC_StateMachine StateMachine { get; private set; }
    public NPCData Data;

    public BoxCollider2D EnemyBoxCollider { get; set; }
    public Rigidbody2D NpcRigidbody { get; private set; }
    public Animator NpcAnimator { get; private set; }
    public GameObject AliveGameObject { get; private set; }
    public AnimationToStateMachine AnimToStateMachine { get; private set; }

    public int FacingDirection { get; private set; }
    public bool CanStartDialogue { get; private set; }
    public bool DialogueStarted { get; private set; }

    [SerializeField] private Transform _wallCheck;
    [SerializeField] private Transform _ledgeCheck;
    [SerializeField] private Vector2 _boxCastSize;
    [SerializeField] private BoxCollider2D _dialogueCollider;

    private Vector2 _velocityWorkspace;

    public virtual void Start()
    {
        StateMachine = new NPC_StateMachine();
        FacingDirection = 1;

        AliveGameObject = transform.Find("AliveNPC").gameObject;
        NpcRigidbody = GetComponent<Rigidbody2D>();
        EnemyBoxCollider = GetComponent<BoxCollider2D>();
        NpcAnimator = AliveGameObject.GetComponent<Animator>();
        AnimToStateMachine = AliveGameObject.GetComponent<AnimationToStateMachine>();
    }

    public virtual void OnEnable()
    {
        PlayerDialogueState.OnDialogueStarted += CheckIfDialogueIsStarted;
        DialogueManager.OnDialogueEnded += EndDialogue;
    }

    public virtual void OnDisable()
    {
        PlayerDialogueState.OnDialogueStarted -= CheckIfDialogueIsStarted;
        DialogueManager.OnDialogueEnded -= EndDialogue;
    }

    public virtual void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        _velocityWorkspace.Set(FacingDirection * velocity, NpcRigidbody.velocity.y);
        NpcRigidbody.velocity = _velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.BoxCast(_wallCheck.position, _boxCastSize, 0, AliveGameObject.transform.right, Data.WallCheckDistance, Data.GroundLayer);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(_ledgeCheck.position, Vector2.down, Data.LedgeCheckDistance, Data.GroundLayer);
    }

    public virtual void CheckIfDialogueIsStarted(bool isStarted)
    {
        if (CanStartDialogue && !DialogueStarted)
        {
            DialogueStarted = true;
        }
    }

    public virtual void DisableDialogueCollider()
    {
        StartCoroutine(DisableDialogueColliderCoroutine());
    }

    private IEnumerator DisableDialogueColliderCoroutine()
    {
        _dialogueCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        _dialogueCollider.enabled = true;
    }

    public virtual void CheckIfPlayerInCollider(bool inCollider)
    {
        CanStartDialogue = inCollider;
    }

    public virtual void EndDialogue()
    {
        DialogueStarted = false;
    }

    public void SetZeroGravity()
    {
        NpcRigidbody.gravityScale = 0;
    }

    public virtual void Flip()
    {
        FacingDirection *= -1;
        AliveGameObject.transform.Rotate(0, 180f, 0);
    }
}
