using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallGrabState WallGrabState { get; private set; }
    public PlayerWallClimbState WallClimbState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerLedgeClimbState LedgeClimbState { get; private set; }
    public PlayerAttackState PrimaryAttackState { get; private set; }
    public PlayerAttackState SecondaryAttackState { get; private set; }
    public PlayerDialogueState DialogueState { get; private set; }

    public PlayerInventory Inventory { get; private set; }

    public Animator PlayerAnimator { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }

    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }
    public bool DialogueStarted { get; private set; }
    public bool CanStartDialogue { get; private set; }

    private Vector2 _workspace;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private Transform _ledgeCheck;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, _playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, _playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, _playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, _playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, _playerData, "land");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, _playerData, "wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, _playerData, "wallGrab");
        WallClimbState = new PlayerWallClimbState(this, StateMachine, _playerData, "wallClimb");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, _playerData, "inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, _playerData, "ledgeClimbState");
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, _playerData, "attack");
        SecondaryAttackState = new PlayerAttackState(this, StateMachine, _playerData, "attack");
        DialogueState = new PlayerDialogueState(this, StateMachine, _playerData, "idle");
    }

    private void Start()
    {
        Inventory = GetComponent<PlayerInventory>();

        PlayerAnimator = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Rigidbody = GetComponent<Rigidbody2D>();

        FacingDirection = 1;

        PrimaryAttackState.SetWeapon(Inventory.Weapons[(int)CombatInputs.primary]);

        StateMachine.Init(IdleState);
    }

    private void OnEnable()
    {
        DialogueManager.OnInputEnabled += SetInputEnabled;
        PlayerDialogueState.OnDialogueStarted += SetIfIsDialogueStarted;
        DialogueManager.OnDialogueEnded += EndDialogue;
    }

    private void OnDisable()
    {
        DialogueManager.OnInputEnabled -= SetInputEnabled;
        PlayerDialogueState.OnDialogueStarted -= SetIfIsDialogueStarted;
        DialogueManager.OnDialogueEnded += EndDialogue;
    }

    private void Update()
    {
        CurrentVelocity = Rigidbody.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    /*public void SetRigidbodyGravityScale() => Rigidbody.gravityScale = 5;*/

    public void SetVelocityZero()
    {
        Rigidbody.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
        /*Rigidbody.gravityScale = 0;*/
    }

    public void SetVelocityX(float velocity)
    {
        _workspace.Set(velocity, CurrentVelocity.y);
        Rigidbody.velocity = _workspace;
        CurrentVelocity = _workspace;
    }

    public void SetVelocityY(float velocity)
    {
        _workspace.Set(CurrentVelocity.x, velocity);
        Rigidbody.velocity = _workspace;
        CurrentVelocity = _workspace;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        _workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        Rigidbody.velocity = _workspace;
        CurrentVelocity = _workspace;
    }

    private void SetIfIsDialogueStarted()
    {
        if (CanStartDialogue && !DialogueStarted)
        {
            DialogueStarted = true;
        }
    }

    private void EndDialogue()
    {
        DialogueStarted = false;
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _playerData.GroundCheckRadius, _playerData.GroundLayer);
    }

    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(_wallCheck.position, Vector2.right * FacingDirection, _playerData.WallCheckDistance, _playerData.GroundLayer);
    }

    public bool CheckIfTouchingWallBack()
    {
        return Physics2D.Raycast(_wallCheck.position, Vector2.right * -FacingDirection, _playerData.WallCheckDistance, _playerData.GroundLayer);
    }

    public bool CheckIfTouchingLedge()
    {
        return Physics2D.Raycast(_ledgeCheck.position, Vector2.right * FacingDirection, _playerData.WallCheckDistance, _playerData.GroundLayer);
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
            Flip();
    }

    public Vector2 DetermineCornerPosition()
    {
        RaycastHit2D xHit = Physics2D.Raycast(_wallCheck.position, Vector2.right * FacingDirection, _playerData.WallCheckDistance, _playerData.GroundLayer);
        float xDistance = xHit.distance;
        _workspace.Set(xDistance * FacingDirection, 0);
        RaycastHit2D yHit = Physics2D.Raycast(_ledgeCheck.position + (Vector3)(_workspace), Vector2.down, _ledgeCheck.position.y - _wallCheck.position.y, _playerData.GroundLayer);
        float yDistance = yHit.distance;

        _workspace.Set(_wallCheck.position.x + (xDistance * FacingDirection), _ledgeCheck.position.y - yDistance);
        return _workspace;
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dialogue"))
            CanStartDialogue = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dialogue"))
            CanStartDialogue = false;
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }

    private void SetInputEnabled(bool enabled) => GetComponent<PlayerInput>().enabled = enabled;
}
