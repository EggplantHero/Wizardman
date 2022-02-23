using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }
    public AudioManager audioManager { get; private set; }
    public Animator animator { get; private set; }
    public Rigidbody2D rbody { get; private set; }
    public Movement movement { get; private set; }
    public CollisionSenses collisionSenses { get; private set; }
    public Combat combat { get; private set; }
    public PlayerInput playerInput { get; private set; }

    public virtual void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        stateMachine = GetComponentInChildren<StateMachine>();
        movement = GetComponentInChildren<Movement>();
        collisionSenses = GetComponentInChildren<CollisionSenses>();
        combat = GetComponentInChildren<Combat>();
        playerInput = GetComponentInChildren<PlayerInput>();
    }

    public virtual void Update()
    {
        if (stateMachine)
            stateMachine.CurrentState.Update();
    }
    public virtual void FixedUpdate()
    {
        if (stateMachine)
            stateMachine.CurrentState.FixedUpdate();
    }

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (stateMachine)
            stateMachine.CurrentState.OnCollisionEnter2D(col);
    }
    public virtual void OnCollisionExit2D(Collision2D col)
    {
        if (stateMachine)
            stateMachine.CurrentState.OnCollisionExit2D(col);
    }
    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (stateMachine)
            stateMachine.CurrentState.OnTriggerEnter2D(col);
    }
    public virtual void OnTriggerExit2D(Collider2D col)
    {
        if (stateMachine)
            stateMachine.CurrentState.OnTriggerExit2D(col);
    }

    public void ExitState()
    {
        if (stateMachine)
            stateMachine.CurrentState.ExitState();
    }
}
