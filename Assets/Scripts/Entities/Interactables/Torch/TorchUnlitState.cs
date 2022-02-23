using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchUnlitState : State
{

    private GameObject lights;

    public TorchUnlitState(Torch entity, string animation) : base(entity, animation)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("unlit state");
        base.OnEnter();
        lights = entity.transform.Find("Light").gameObject;
        lights.SetActive(false);
    }

    public override void Update()
    {
        base.Update();
    }


}
