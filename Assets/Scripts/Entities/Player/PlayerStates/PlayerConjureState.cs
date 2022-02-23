using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConjureState : PlayerCastState
{
    public PlayerConjureState(Player player, string animation) : base(player, animation)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (!player.collisionSenses.grounded)
        {
            player.movement.SetVelocityY(playerData.conjureRecoil * Movement.gravityDirection);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        base.Update();

        if (player.collisionSenses.grounded)
        {
            player.movement.SetVelocityX(0);
        }
    }
}
