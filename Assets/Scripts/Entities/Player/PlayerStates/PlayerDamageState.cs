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
        // Debug.Log("entering damaaged state");
        base.OnEnter();
        player.collisionSenses.SetMaterial(player.collisionSenses.Bouncy);
    }

    public override void OnExit()
    {
        // Debug.Log("on exit hook");
        base.OnExit();
        player.collisionSenses.SetMaterial(player.collisionSenses.ZeroFriction);
    }

    public override void ExitState()
    {
        // Debug.Log("exiting state");
        player.stateMachine.SetState(player.IdleState);
    }

}
