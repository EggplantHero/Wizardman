using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireballState : PlayerConjureState
{
    public PlayerFireballState(Player player, string animation) : base(player, animation)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        ShootFireball();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    void ShootFireball()
    {
        Spell projectile = GameObject.Instantiate(playerData.fireball, player.transform.position, Quaternion.identity);
        Entity fireball = projectile.GetComponent<Entity>();
        fireball.movement.SetVelocityX(playerData.fireballSpeed * player.movement.facingDirectionX);
        fireball.movement.FlipX(player.movement.facingDirectionX);
    }

    public override void Update()
    {
        base.Update();
    }
}
