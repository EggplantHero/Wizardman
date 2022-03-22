using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOffState : State
{
    public Switch swtch;
    public SwitchOffState(Switch entity, string animation) : base(entity, animation)
    {
        this.swtch = entity;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        swtch.TurnOff();
    }

    public override void Update()
    {
        base.Update();
    }
}
