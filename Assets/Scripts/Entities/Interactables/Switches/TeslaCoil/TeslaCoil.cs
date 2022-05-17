using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaCoil : Switch, ITriggerable
{
    public CoilOnState LitState { get; private set; }
    public CoilOffState UnlitState { get; private set; }
    public GameObject lights { get; private set; }
    public int rotation;

    public override void Awake()
    {
        base.Awake();
        LitState = new CoilOnState(this, "Lit");
        UnlitState = new CoilOffState(this, "Unlit");
        lights = transform.Find("Light").gameObject;
    }

    public void Start()
    {
        if (On)
        {
            stateMachine.Initialize(LitState);
        }
        else
        {
            stateMachine.Initialize(UnlitState);
        }
        transform.Rotate(0, 0, rotation);
    }

    public void Trigger(DamageType damageType)
    {
        stateMachine.CurrentState.OnTrigger(damageType);
    }

}
