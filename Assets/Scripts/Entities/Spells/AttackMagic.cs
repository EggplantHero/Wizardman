using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackMagic : Spell
{
    [SerializeField] private int damage;
    [SerializeField] private DamageType damageType;
    [SerializeField] private float knockbackStrength;
    [SerializeField] private SoundType castSFX;
    [SerializeField] public SoundType OnHitSFX;
    [SerializeField] public bool destroyOnHit;
    private bool sfxAvailable = true;
    public virtual void Start()
    {
        Debug.Log("fireball start");
        Debug.Log(castSFX);
        Debug.Log(Singleton.Main.AudioManager.sfx_damage_track);
        Singleton.Main.AudioManager.Play(castSFX, Singleton.Main.AudioManager.sfx_damage_track);
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("existing...");
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        DealDamage(col);
    }
    public override void OnCollisionEnter2D(Collision2D col)
    {
        DealDamage(col.collider);
        if (destroyOnHit)
        {
            PlaySFX();
            Destroy(this.gameObject);
        };
    }

    public void DealDamage(Collider2D col)
    {
        if (!col.IsTouching(collisionSenses.Hitbox)) return;

        Entity entity = col.transform.GetComponentInParent<Entity>();
        if (entity == null) return;
        if (col.name != "Body") return;

        ITriggerable triggerable = entity.GetComponentInChildren<ITriggerable>();
        IDamageable damageable = entity.GetComponentInChildren<IDamageable>();
        if (triggerable != null)
        {
            triggerable.Trigger(damageType);
        }
        if (damageable != null)
        {
            if (entity.combat.Vulnerabilities.Contains(damageType))
            {
                PlaySFX();
                damageable.Damage(damage, damageType);
                Vector2 direction = entity.transform.position - transform.position;
                damageable.Knockback(direction, knockbackStrength);
            }
        }
    }

    public void PlaySFX()
    {
        if (sfxAvailable) Singleton.Main.AudioManager.Play(OnHitSFX, Singleton.Main.AudioManager.sfx_damage_track);
        sfxAvailable = false;
    }
}
