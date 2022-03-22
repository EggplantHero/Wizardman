using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : Lock
{
    public GateLockedState GateLockedState { get; private set; }
    public GateUnlockedState GateUnlockedState { get; private set; }


    public override void Awake()
    {
        base.Awake();
        GateLockedState = new GateLockedState(this, "Locked");
        GateUnlockedState = new GateUnlockedState(this, "Unlocked");
    }

    public void Start()
    {
        stateMachine.Initialize(GateLockedState);
    }
}
