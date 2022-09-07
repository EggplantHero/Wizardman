using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AttackMagic : Spell
{
    [SerializeField] private int damage;
    [SerializeField] private DamageType damageType;
    [SerializeField] private float knockbackStrength;
    [SerializeField] private SoundType castSFX;
    [SerializeField] public SoundType OnHitSFX;
    [SerializeField] public bool destroyThisOnHit;
    private bool sfxAvailable = true;
    public virtual void Start()
    {
        Singleton.Main.AudioManager.Play(castSFX);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        DealDamage(col);
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);

        DealDamage(col.collider);

        if (destroyThisOnHit)
        {
            PlaySFX();
            Destroy(this.gameObject);
        };
    }

    public override void OnCollisionStay2D(Collision2D col)
    {
        base.OnCollisionStay2D(col);
    }

    public virtual void DealDamage(Collider2D col)
    {
        if (!col.IsTouching(collisionSenses.Hitbox)) return;

        if (col.gameObject.name == "Breakable")
        {
            Singleton.Main.AudioManager.Play(SoundType.SFX_FireballExplosion);
            DestroyTerrain(col, this.transform.position, 1.5f);
            return;
        };

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
            PlaySFX();
            damageable.Damage(damage, damageType);
            Vector2 direction = entity.transform.position - transform.position;
            damageable.Knockback(direction, knockbackStrength);
        }
    }

    public void PlaySFX()
    {
        //sfxAvailable limits sfx play to once in case a spell hits multiple colliders
        if (sfxAvailable) Singleton.Main.AudioManager.Play(OnHitSFX);
        sfxAvailable = false;
    }

    public void DestroyTerrain(Collider2D col, Vector3 explosionLocation, float radius)
    {
        Tilemap[] tilemaps = col.gameObject.GetComponentsInChildren<Tilemap>();
        for (int x = -(int)radius; x < radius; x++)
        {
            for (int y = -(int)radius; y < radius; y++)
            {
                foreach (Tilemap terrain in tilemaps)
                {
                    Vector3Int tilePos = terrain.WorldToCell(explosionLocation + new Vector3(x, y, 0));
                    if (terrain.GetTile(tilePos) != null)
                    {
                        terrain.SetTile(tilePos, null);
                    }
                }
            }
        }
        foreach (Tilemap terrain in tilemaps)
        {
            if (terrain.GetUsedTilesCount() <= 0)
            {
                terrain.gameObject.SetActive(false);
            }
        }
    }
}
