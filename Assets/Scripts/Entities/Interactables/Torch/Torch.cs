using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Entity, ITriggerable
{
    public TorchLitState LitState { get; private set; }
    public TorchUnlitState UnlitState { get; private set; }

    private GameObject lights;

    public bool lit;
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
        if (lit)
        {
            stateMachine.Initialize(LitState);
            lights.SetActive(true);
        }
        else
        {
            stateMachine.Initialize(UnlitState);
            lights.SetActive(false);
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
