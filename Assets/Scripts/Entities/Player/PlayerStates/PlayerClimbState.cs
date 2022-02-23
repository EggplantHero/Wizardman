using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbState : PlayerState
{
    public PlayerClimbState(Player player, string animation) : base(player, animation)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        player.movement.SetVelocityX(0);
        player.movement.SetGravity(0);
        player.castAvailable = true;
    }

    public override void OnExit()
    {
        player.movement.ResetGravity();
    }

    public override void OnMove(float input)
    {
    }

    public override void OnClimb(float input)
    {
        player.movement.SetVelocityY(input * playerData.climbSpeed * Movement.gravityDirection);
        if (input == 0)
        {
            player.animator.Play("Climbing Idle");
        }
        else
        {
            player.animator.Play("Climbing");
        }
    }

    public override void OnJump(float input)
    {
        player.movement.SetVelocityY(playerData.ladderExitSpeed * Movement.gravityDirection);
        stateMachine.SetState(player.AerialState);
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if (player.collisionSenses.grounded)
        {
            player.stateMachine.SetState(player.OpenState);
        }
    }

    public override void OnTriggerExit2D(Collider2D col)
    {
        if (!player.collisionSenses.touchingLadder)
        {
            player.stateMachine.SetState(player.OpenState);
        }
    }

    public override void Update()
    {
        base.Update();
        player.movement.SetVelocityX(0);
    }
}
