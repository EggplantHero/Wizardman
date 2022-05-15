using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icecube : AttackMagic
{
    private float defaultMass;
    public override void Start()
    {
        base.Start();
        defaultMass = rbody.mass;
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
        Debug.Log(col.collider.name);
        if (col.collider.name == "Terrain")
        {
            Singleton.Main.AudioManager.Play(SoundType.SFX_IceCollision);
        }
    }
    public override void Update()
    {
        base.Update();
        if (collisionSenses.grounded)
        {
            movement.SetGravity(0);
            movement.SetMass(defaultMass);
        }
        else
        {
            movement.ResetGravity();
            movement.SetMass(10000);
        }
    }
}
