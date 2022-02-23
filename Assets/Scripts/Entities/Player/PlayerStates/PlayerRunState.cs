using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerOpenState
{
    public PlayerRunState(Player player, string animation) : base(player, animation)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnMove(float input)
    {
        base.OnMove(input);
        if (input == 0)
        {
            player.stateMachine.SetState(player.IdleState);
        }
    }

    public override void OnJump(float input)
    {
        base.OnJump(input);
    }

    public override void Update()
    {
        base.Update();
    }
}
