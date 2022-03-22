using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icecube : AttackMagic
{
    private float defaultMass;
    public void Start()
    {
        defaultMass = rbody.mass;
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
