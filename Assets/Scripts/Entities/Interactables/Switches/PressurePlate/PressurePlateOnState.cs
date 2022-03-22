using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateOnState : SwitchOnState
{
    public PressurePlate plate;

    ContactFilter2D filter = new ContactFilter2D();
    Collider2D[] results = new Collider2D[10];


    public PressurePlateOnState(PressurePlate entity, string animation) : base(entity, animation)
    {
        this.plate = entity;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnTriggerExit2D(Collider2D col)
    {
        base.OnTriggerExit2D(col);
        if (col.name == "Feet")
            plate.stateMachine.SetState(plate.PlateOffState);
    }


    public override void Update()
    {
        base.Update();

        plate.collisionSenses.HeadCollider.OverlapCollider(filter.NoFilter(), results);

        bool feetfound = false;
        foreach (var collider in results)
        {
            if (!collider) continue;
            if (collider.name == "Feet")
            {
                feetfound = true;
                return;
            };
        }
        if (!feetfound)
            plate.stateMachine.SetState(plate.PlateOffState);
    }
}
