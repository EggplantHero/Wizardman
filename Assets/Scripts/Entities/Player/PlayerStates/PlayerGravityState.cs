using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityState : PlayerCastState
{
    public PlayerGravityState(Player player, string animation) : base(player, animation)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Movement.InvertGravity();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
