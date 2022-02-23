using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player player, string animation) : base(player, animation)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        player.movement.SetVelocityY(playerData.jumpVelocity * Movement.gravityDirection);
        player.stateMachine.SetState(player.AerialState);
        player.audioManager.Play(playerData.jumpSFX, player.audioManager.sfx_movement_track);
    }
}
