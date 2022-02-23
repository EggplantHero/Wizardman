using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimestopState : PlayerCastState
{
    public PlayerTimestopState(Player player, string animation) : base(player, animation)
    {
    }
    public Clock clock;


    public override void OnEnter()
    {
        base.OnEnter();
        clock = player.GetComponentInChildren<Clock>(true);
        clock.Display(true);
        clock.ResetAll();
        Time.timeScale = playerData.timeStopScale;
    }

    public override void OnJump(float input)
    {
        base.OnJump(input);
        Vector2 LaunchAngle = Quaternion.Euler(0, 0, clock.minuteHand.angle) * new Vector2(1, 0);
        Debug.Log(LaunchAngle);
        player.movement.AddKnockback(LaunchAngle, playerData.timestopKnockback);
        player.stateMachine.SetState(player.DamageState);
    }

    public override void OnCast(float input)
    {
        base.OnCast(input);
        ExitState();
    }

    public override void FixedUpdate()
    {
        base.Update();
        player.audioManager.Play(playerData.clockSFX, player.audioManager.sfx_movement_track);
        clock.secondHand.angle += -playerData.deltaTick;
        clock.secondHand.Rotate(clock.secondHand.angle);

    }

    public override void OnMove(float input)
    {
        base.OnMove(input);
        if (player.playerInput.movementInput != 0)
        {
            clock.minuteHand.angle += playerData.deltaTick * -player.playerInput.movementInput;
            clock.minuteHand.Rotate(clock.minuteHand.angle);

            clock.hourHand.angle += playerData.deltaTick / 12 * -player.playerInput.movementInput;
            clock.hourHand.Rotate(clock.hourHand.angle);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        Time.timeScale = 1f;
        clock.Display(false);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
