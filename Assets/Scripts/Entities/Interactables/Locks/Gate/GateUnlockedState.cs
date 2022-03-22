using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateUnlockedState : UnlockedState
{
    public Gate gate;
    public GateUnlockedState(Gate entity, string animation) : base(entity, animation)
    {
        this.gate = entity;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        gate.collisionSenses.BodyCollider.enabled = false;
    }

    public override void Update()
    {
        base.Update();
        if (gate.locked)
        {
            gate.stateMachine.SetState(gate.GateLockedState);
        }
    }
}
