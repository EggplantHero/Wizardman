using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Entity entity;
    protected StateMachine stateMachine;
    private string animation;

    public State(Entity entity, string animation)
    {
        this.entity = entity;
        this.animation = animation;
        this.stateMachine = entity.stateMachine;
    }

    #region Unity Callbacks

    public virtual void OnEnter()
    {
        entity.animator.Play(animation);
    }
    public virtual void OnExit() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void OnCollisionEnter2D(Collision2D col) { }
    public virtual void OnCollisionExit2D(Collision2D col) { }
    public virtual void OnTriggerEnter2D(Collider2D col) { }
    public virtual void OnTriggerExit2D(Collider2D col) { }
    public virtual void OnTriggerStay2D(Collider2D col) { }

    #endregion

    #region Player Controls
    public virtual void OnMove(float input) { }
    public virtual void OnJump(float input) { }
    public virtual void OnCast(float input) { }
    public virtual void OnClimb(float input) { }
    #endregion

    #region Interfaces
    public virtual void OnDamage(int amount, DamageType damageType) { }
    public virtual void OnKnockback(Vector2 direction, float strength) { }
    public virtual void OnTrigger(DamageType damageType) { }
    #endregion

    #region Animation Events
    public virtual void ExitState() { }
    #endregion
}