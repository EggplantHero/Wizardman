using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAerialState : PlayerOpenState
{
    public PlayerAerialState(Player player, string animation) : base(player, animation)
    {
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if (player.collisionSenses.grounded)
        {
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

    public override void OnJump(float input)
    {

    }

    public override void Update()
    {
        base.Update();
    }
}
