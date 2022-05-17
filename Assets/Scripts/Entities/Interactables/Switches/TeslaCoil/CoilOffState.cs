using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilOffState : SwitchOffState
{

    private TeslaCoil coil;

    public CoilOffState(TeslaCoil entity, string animation) : base(entity, animation)
    {
        this.coil = entity;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        coil.lights.SetActive(false);
    }

    public override void OnTrigger(DamageType damageType)
    {
        base.OnTrigger(damageType);
        if (damageType == DamageType.DMG_Lightning)
        {
            coil.stateMachine.SetState(coil.LitState);
        }
    }


}
