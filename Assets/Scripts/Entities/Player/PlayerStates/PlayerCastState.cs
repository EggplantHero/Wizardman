using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastState : PlayerState
{

    public PlayerCastState(Player player, string animation) : base(player, animation)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        player.castAvailable = false;
        if (player.inventory.equippedSpell.spell == SpellType.SPELL_None)
        {
            player.animator.Play("Casting");
        }
        if (player.inventory.equippedSpell.spell == SpellType.SPELL_Fireball)
        {
            player.stateMachine.SetState(player.FireballState);
        }
        if (player.inventory.equippedSpell.spell == SpellType.SPELL_Frost)
        {
            player.stateMachine.SetState(player.FrostState);
        }
        if (player.inventory.equippedSpell.spell == SpellType.SPELL_Lightning)
        {
            player.stateMachine.SetState(player.LightningState);
        }
        if (player.inventory.equippedSpell.spell == SpellType.SPELL_Gravity)
        {
            player.stateMachine.SetState(player.GravityState);
        }
        if (player.inventory.equippedSpell.spell == SpellType.SPELL_Timestop)
        {
            player.stateMachine.SetState(player.TimestopState);
        }
    }

    public override void ExitState()
    {
        player.stateMachine.SetState(player.OpenState);
    }

    public override void Update()
    {
        base.Update();

        if (player.collisionSenses.grounded)
        {
            player.movement.SetVelocityX(0);
        }
    }
}
