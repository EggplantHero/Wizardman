using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(Player player, string animation) : base(player, animation)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("DEAD");
    }
}
