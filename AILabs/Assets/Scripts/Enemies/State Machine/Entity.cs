using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    public FiniteStateMachine StateMachine { get; private set; }
    public EntityData Data;

    public BoxCollider2D EnemyBoxCollider { get; set; }
    public Rigidbody2D EnemyRigidbody { get; private set; }
    public Animator EnemyAnimator { get; private set; }
    public GameObject AliveGameObject { get; private set; }
    public AnimationToStateMachine AnimToStateMachine { get; private set; }

    public int FacingDirection { get; private set; }
    public bool IsDead { get; private set; }

    [SerializeField] private Transform _wallCheck;
    [SerializeField] private Transform _ledgeCheck;
    [SerializeField] private Transform _playerCheck;
    [SerializeField] private Vector2 _boxCastSize;

    private Vector2 _velocityWorkspace;

    private float _currentHealth;

    public virtual void Start()
    {
        StateMachine = new FiniteStateMachine();
        FacingDirection = 1;
        _currentHealth = Data.MaxHealth;

        AliveGameObject = transform.Find("Alive").gameObject;
        EnemyRigidbody = GetComponent<Rigidbody2D>();
        EnemyBoxCollider = GetComponent<BoxCollider2D>();
        EnemyAnimator = AliveGameObject.GetComponent<Animator>();
        AnimToStateMachine = AliveGameObject.GetComponent<AnimationToStateMachine>();
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
        _velocityWorkspace.Set(FacingDirection * velocity, EnemyRigidbody.velocity.y);
        EnemyRigidbody.velocity = _velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.BoxCast(_wallCheck.position, _boxCastSize, 0, AliveGameObject.transform.right, Data.WallCheckDistance, Data.GroundLayer);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(_ledgeCheck.position, Vector2.down, Data.LedgeCheckDistance, Data.GroundLayer);
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(_playerCheck.position, AliveGameObject.transform.right, Data.MinAgroDistance, Data.PlayerLayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(_playerCheck.position, AliveGameObject.transform.right, Data.MaxAgroDistance, Data.PlayerLayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(_playerCheck.position, AliveGameObject.transform.right, Data.CloseRangeActionDistance, Data.PlayerLayer);
    }

    public void SetZeroGravity()
    {
        EnemyRigidbody.gravityScale = 0;
    }

    public virtual void Damage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            IsDead = true;
        }
    }

    public virtual void Flip()
    {
        FacingDirection *= -1;
        AliveGameObject.transform.Rotate(0, 180f, 0);
    }

    /*public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(_wallCheck.position, _wallCheck.position + (Vector3)(Vector2.right * FacingDirection * Data.WallCheckDistance));
        Gizmos.DrawLine(_ledgeCheck.position, _ledgeCheck.position + (Vector3)(Vector2.down * Data.LedgeCheckDistance));
        Gizmos.DrawLine(_playerCheck.position, _playerCheck.position + (Vector3)(Vector2.right * Data.MinAgroDistance * FacingDirection));
        Gizmos.DrawWireSphere(_playerCheck.position + (Vector3)(AliveGameObject.transform.right * Data.CloseRangeActionDistance), 0.2f);
        Gizmos.DrawWireSphere(_playerCheck.position + (Vector3)(AliveGameObject.transform.right * Data.MinAgroDistance), 0.2f);
        Gizmos.DrawWireSphere(_playerCheck.position + (Vector3)(AliveGameObject.transform.right * Data.MaxAgroDistance), 0.2f);
        Gizmos.DrawWireCube(_wallCheck.position, _boxCastSize);
    }*/
}
