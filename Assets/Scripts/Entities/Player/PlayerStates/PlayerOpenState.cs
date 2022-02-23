using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenState : PlayerState
{
    public PlayerOpenState(Player player, string animation) : base(player, animation)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (!player.collisionSenses.grounded)
        {
            player.stateMachine.SetState(player.AerialState);
        }
        else
        {
            player.castAvailable = true;

            if (player.playerInput.movementInput == 0)
            {
                player.stateMachine.SetState(player.IdleState);
            }
            else
            {
                player.stateMachine.SetState(player.RunState);
            }
        }

    }

    public override void OnMove(float input)
    {
    }

    public override void OnJump(float input)
    {
        player.stateMachine.SetState(player.JumpState);
    }

    public override void OnClimb(float input)
    {
        if (input != 0 && player.collisionSenses.touchingLadder)
        {
            player.stateMachine.SetState(player.ClimbState);
        }
    }

    public override void OnCast(float input)
    {
        if (player.castAvailable)
        {
            player.stateMachine.SetState(player.CastState);
        }
    }

    public override void Update()
    {
        player.movement.FlipX(player.playerInput.movementInput);
        player.movement.SetVelocityX(player.movement.movementSpeed * player.playerInput.movementInput);
    }

    public override void OnCollisionExit2D(Collision2D col)
    {
        base.OnCollisionExit2D(col);

        if (!player.collisionSenses.grounded)
        {
            player.stateMachine.SetState(player.AerialState);
        }
    }
}
