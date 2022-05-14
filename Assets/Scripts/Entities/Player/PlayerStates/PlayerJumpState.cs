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
        Singleton.Main.AudioManager.Play(playerData.jumpSFX, Singleton.Main.AudioManager.sfx_movement_track);
    }
}
