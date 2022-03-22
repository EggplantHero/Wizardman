using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateOffState : SwitchOffState
{
    public PressurePlate plate;

    public PressurePlateOffState(PressurePlate entity, string animation) : base(entity, animation)
    {
        this.plate = entity;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        if (col.name == "Feet")
            plate.stateMachine.SetState(plate.PlateOnState);
    }
}
