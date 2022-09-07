using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icecube : AttackMagic
{
    public float defaultMass { get; set; }
    public float heavyMass { get; set; }

    public IcecubeAirState airState { get; private set; }
    public IcecubeGroundedState groundedState { get; private set; }

    public override void Awake()
    {
        base.Awake();
        airState = new IcecubeAirState(this, "none");
        groundedState = new IcecubeGroundedState(this, "none");
    }
    public override void Start()
    {
        base.Start();
        defaultMass = rbody.mass;
        heavyMass = 10000;
        rbody.mass = heavyMass;
        stateMachine.Initialize(airState);
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
        if (col.collider.name == "Terrain")
        {
            Singleton.Main.AudioManager.Play(SoundType.SFX_IceCollision);
        }

        CrushEnemy(col);
    }

    public override void OnCollisionStay2D(Collision2D col)
    {
        base.OnCollisionStay2D(col);

        CrushEnemy(col);
    }

    //allowedDifference between 0 and 1
    public bool Approximately(Vector2 me, Vector2 other, float allowedDifference)
    {
        var dx = me.x - other.x;
        if (Mathf.Abs(dx) > allowedDifference)
        {
            return false;
        }

        var dy = me.y - other.y;
        if (Mathf.Abs(dy) >= allowedDifference)
        {
            return false;
        }
        return true;
    }

    private void CrushEnemy(Collision2D col)
    {
        Entity entity = col.transform.GetComponentInParent<Entity>();
        if (entity is null) return;

        if (!(col.collider.name == "Body" || col.collider.name == "PlayerBody")) return;

        IDamageable damageable = entity.GetComponentInChildren<IDamageable>();

        if (damageable is null) return;

        Vector2 distance = entity.transform.position - this.transform.position;
        if (Approximately(this.rbody.velocity.normalized, distance.normalized, 1f) is false) return;
        if (!((entity.collisionSenses.grounded && entity.collisionSenses.stomped) || (entity.collisionSenses.backToWall && entity.collisionSenses.facingWall))) return;

        Singleton.Main.AudioManager.Play(OnHitSFX);
        damageable.Die();
    }
}
