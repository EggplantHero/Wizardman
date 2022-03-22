using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLockedState : LockedState
{
    public Gate gate;
    public GateLockedState(Gate entity, string animation) : base(entity, animation)
    {
        this.gate = entity;
    }

    public override void OnEnter()
    {

        base.OnEnter();
        gate.collisionSenses.BodyCollider.enabled = true;
    }

    public override void Update()
    {
        base.Update();
        if (!gate.locked)
        {
            gate.stateMachine.SetState(gate.GateUnlockedState);
        }
    }
}
