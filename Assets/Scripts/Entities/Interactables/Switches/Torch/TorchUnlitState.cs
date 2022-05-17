using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchUnlitState : SwitchOffState
{

    private Torch torch;

    public TorchUnlitState(Torch entity, string animation) : base(entity, animation)
    {
        this.torch = entity;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        torch.lights.SetActive(false);
    }

    public override void OnTrigger(DamageType damageType)
    {
        base.OnTrigger(damageType);
        if (damageType == DamageType.DMG_Fire)
        {
            torch.stateMachine.SetState(torch.LitState);
        }
    }


}
