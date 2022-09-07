using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcecubeGroundedState : State
{
    public Icecube icecube;
    public IcecubeGroundedState(Icecube entity, string animation) : base(entity, animation)
    {
        this.icecube = entity;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        icecube.movement.SetGravity(0);
        icecube.collisionSenses.BodyCollider.gameObject.layer = LayerMask.NameToLayer("Ground");
        icecube.collisionSenses.FeetCollider.gameObject.layer = LayerMask.NameToLayer("Ground");
        icecube.collisionSenses.Hitbox.enabled = false;
    }

    public override void Update()
    {
        base.Update();
        if (!icecube.collisionSenses.grounded)
        {
            icecube.stateMachine.SetState(icecube.airState);
        }
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
        if (col.collider.name == "PlayerBody" && icecube.rbody.mass != icecube.defaultMass)
        {
            icecube.rbody.mass = icecube.defaultMass;
        }
    }

    public override void OnCollisionExit2D(Collision2D col)
    {
        base.OnCollisionExit2D(col);
        if (col.collider.name == "PlayerBody" && icecube.rbody.mass != icecube.heavyMass)
        {
            icecube.rbody.mass = icecube.heavyMass;
        }
    }
}
