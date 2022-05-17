using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity

{
    [SerializeField] private float knockbackStrength;
    [SerializeField] private int damage;
    public override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            DamagePlayer(col, DamageType.DMG_Physical);
        }
    }

    public void DamagePlayer(Collision2D col, DamageType damageType)
    {
        Player player = col.gameObject.GetComponent<Player>();
        player.combat.Damage(damage, damageType);
        Singleton.Main.UIManager.Health.HandleDamage(player.combat.CurrentHealth);
        player.combat.SetImmuneTimed(2);

        Vector2 direction = col.transform.position - transform.position;
        player.stateMachine.SetState(player.DamageState);
        player.combat.Knockback(direction, knockbackStrength);

        Singleton.Main.AudioManager.Play(SoundType.SFX_TakeDamage);
    }
}
