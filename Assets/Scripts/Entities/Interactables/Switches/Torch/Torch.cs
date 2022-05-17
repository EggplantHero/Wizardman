using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Switch, ITriggerable
{
    public TorchLitState LitState { get; private set; }
    public TorchUnlitState UnlitState { get; private set; }
    public GameObject lights { get; private set; }
    public bool flip;

    public override void Awake()
    {
        base.Awake();
        LitState = new TorchLitState(this, "Lit");
        UnlitState = new TorchUnlitState(this, "Unlit");
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
        if (flip)
        {
            transform.Rotate(0, 180, 0);
        }
    }

    public void Trigger(DamageType damageType)
    {
        stateMachine.CurrentState.OnTrigger(damageType);
    }

}
