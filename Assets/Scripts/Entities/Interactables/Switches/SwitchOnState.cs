using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnState : State
{
    public Switch swtch;
    public SwitchOnState(Switch entity, string animation) : base(entity, animation)
    {
        this.swtch = entity;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        swtch.TurnOn();
    }

    public override void Update()
    {
        base.Update();
    }
}
