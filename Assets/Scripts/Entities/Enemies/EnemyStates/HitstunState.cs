using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitstunState : State
{
    public HitstunState(Entity entity, string animation) : base(entity, animation)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        entity.collisionSenses.SetMaterial(entity.collisionSenses.Bouncy);

    }

    public override void Update()
    {
        base.Update();
    }

    public override void ExitState()
    {
        entity.collisionSenses.SetMaterial(entity.collisionSenses.ZeroFriction);
        entity.combat.SetHitstun(false);
        base.ExitState();
    }
}
