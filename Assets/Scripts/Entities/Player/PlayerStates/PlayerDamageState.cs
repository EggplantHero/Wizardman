using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageState : PlayerState
{
    public PlayerDamageState(Player player, string animation) : base(player, animation)
    {
    }
    public override void OnEnter()
    {
        base.OnEnter();
        player.collisionSenses.SetMaterial(player.collisionSenses.Bouncy);
    }

    public override void OnExit()
    {
        base.OnExit();
        player.collisionSenses.SetMaterial(player.collisionSenses.ZeroFriction);
    }

    public override void ExitState()
    {
        player.stateMachine.SetState(player.IdleState);
    }

}
