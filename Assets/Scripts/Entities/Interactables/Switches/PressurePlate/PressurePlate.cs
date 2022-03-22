using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Switch
{
    public PressurePlateOnState PlateOnState { get; private set; }
    public PressurePlateOffState PlateOffState { get; private set; }

    public override void Awake()
    {
        base.Awake();
        PlateOnState = new PressurePlateOnState(this, "Pressed");
        PlateOffState = new PressurePlateOffState(this, "NotPressed");
    }

    public void Start()
    {
        stateMachine.Initialize(PlateOffState);
    }

}
