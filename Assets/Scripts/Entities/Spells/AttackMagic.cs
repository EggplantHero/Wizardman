using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMagic : Spell
{
    [SerializeField] private int damage;
    [SerializeField] private DamageType damageType;
    [SerializeField] private float knockbackStrength;
    [SerializeField] private SoundType castSFX;
    [SerializeField] public SoundType OnHitSFX;
    private void Start()
    {
        audioManager.Play(castSFX, audioManager.sfx_damage_track);
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        DealDamage(col);
    }
    public override void OnCollisionEnter2D(Collision2D col)
    {
        DealDamage(col.collider);
    }

    public void DealDamage(Collider2D col)
    {
        if (!col.IsTouching(collisionSenses.Hitbox))
        {
            return;
        }

        Entity entity = col.transform.GetComponentInParent<Entity>();
        if (entity == null)
        {
            return;
        }
        if (col.name != "Body")
        {
            return;
        }

        ITriggerable triggerable = entity.GetComponentInChildren<ITriggerable>();
        IDamageable damageable = entity.GetComponentInChildren<IDamageable>();
        if (triggerable != null)
        {
            triggerable.Trigger(damageType);
        }
        if (damageable != null)
        {
            damageable.Damage(damage, damageType);
            Vector2 direction = entity.transform.position - transform.position;
            damageable.Knockback(direction, knockbackStrength);
            audioManager.Play(OnHitSFX, audioManager.sfx_damage_track);
            Destroy(this.gameObject);
        }
    }
}
