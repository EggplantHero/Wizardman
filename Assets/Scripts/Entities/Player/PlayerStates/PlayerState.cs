using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    protected Player player;
    protected PlayerData playerData;
    public PlayerState(Player player, string animation) : base(player, animation)
    {
        this.player = player;
        this.playerData = player.playerData;
    }

    public override void OnPause(float input)
    {
        base.OnPause(input);
        Singleton.Main.UIManager.PauseGame();
    }
}
