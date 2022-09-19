using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcecubeAirState : State
{
    public Icecube icecube;
    public IcecubeAirState(Icecube entity, string animation) : base(entity, animation)
    {
        this.icecube = entity;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        icecube.movement.ResetGravity();
        icecube.collisionSenses.BodyCollider.gameObject.layer = LayerMask.NameToLayer("Ghost");
        icecube.collisionSenses.FeetCollider.gameObject.layer = LayerMask.NameToLayer("Ghost");
        icecube.collisionSenses.Hitbox.enabled = true;
    }

    public override void Update()
    {
        base.Update();
        if (icecube.collisionSenses.grounded)
        {
            icecube.stateMachine.SetState(icecube.groundedState);
        }
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        icecube.CrushEnemy(col);
    }
}
