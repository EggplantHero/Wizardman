using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightningState : PlayerCastState
{
    public PlayerLightningState(Player player, string animation) : base(player, animation)
    {
    }

    public AttackMagic lightning;

    public override void OnEnter()
    {
        base.OnEnter();

        if (player.collisionSenses.grounded && Movement.gravityDirection == 1)
        {
            player.animator.Play("Casting");
        }
        else
        {
            if (Movement.gravityDirection == -1)
            {
                player.movement.FlipY();
            }
            player.movement.SetVelocityX(0);
            player.movement.SetGravity(0);
            player.movement.SetVelocityY(-playerData.lightningSpeed);
        }
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col);
        base.OnCollisionEnter2D(col);
        player.movement.ResetGravity();
        if (Movement.gravityDirection == -1)
        {
            player.movement.FlipY();
        }

        ExitState();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
