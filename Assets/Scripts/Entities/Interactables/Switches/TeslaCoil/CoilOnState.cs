using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilOnState : SwitchOnState
{
    private TeslaCoil coil;

    public CoilOnState(TeslaCoil entity, string animation) : base(entity, animation)
    {
        this.coil = entity;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        coil.lights.SetActive(true);
    }

    public override void OnTrigger(DamageType damageType)
    {
        base.OnTrigger(damageType);
        if (damageType == DamageType.DMG_Lightning)
        {
            coil.stateMachine.SetState(coil.UnlitState);
        }
    }

}
