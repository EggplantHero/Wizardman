using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLitState : State
{
    private GameObject lights;

    public TorchLitState(Torch entity, string animation) : base(entity, animation)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("lit state");
        base.OnEnter();
        lights = entity.transform.Find("Light").gameObject;
        lights.SetActive(true);
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        Icecube icecube = col.GetComponent<Icecube>();
        AttackMagic fireball = col.GetComponent<AttackMagic>();
    }

    public override void OnTrigger(DamageType damageType)
    {
        base.OnTrigger(damageType);
        if (damageType == DamageType.DMG_Fire)
        {
            // stateMachine.SetState(TorchLitState);
        }
        if (damageType == DamageType.DMG_Ice)
        {
            // stateMachine.SetState(TorchUnlitState);
        }
    }

}
