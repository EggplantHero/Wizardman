using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXState : State
{
    public MoveXState(Entity entity, string animation) : base(entity, animation)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        entity.collisionSenses.SetMaterial(entity.collisionSenses.ZeroFriction);
    }

    public override void Update()
    {
        base.Update();
        entity.movement.SetVelocityX(entity.movement.movementSpeed * entity.movement.facingDirectionX);
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        if (entity.collisionSenses.facingWall)
        {
            entity.movement.TurnAroundX();
        }
    }
}
