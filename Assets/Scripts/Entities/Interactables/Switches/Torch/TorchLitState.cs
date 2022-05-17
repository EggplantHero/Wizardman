using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLitState : SwitchOnState
{
    private Torch torch;

    public TorchLitState(Torch entity, string animation) : base(entity, animation)
    {
        this.torch = entity;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        torch.lights.SetActive(true);
    }

    public override void OnTrigger(DamageType damageType)
    {
        base.OnTrigger(damageType);
        if (damageType == DamageType.DMG_Ice)
        {
            torch.stateMachine.SetState(torch.UnlitState);
        }
    }

}
