﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : Enemy
{
    public override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
        if (col.collider.name == "Feet")
        {
            DamagePlayer(col, DamageType.DMG_Physical);
        }
    }
}
