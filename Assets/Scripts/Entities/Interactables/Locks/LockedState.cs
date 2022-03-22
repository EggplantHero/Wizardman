using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedState : State
{
    public Lock lok;
    public LockedState(Lock entity, string animation) : base(entity, animation)
    {
        this.lok = entity;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        lok.CloseLock();
    }

    public override void Update()
    {
        base.Update();
        foreach (var key in lok.keys)
        {
            if (!key.On)
            {
                return;
            }
        }
        lok.OpenLock();
    }
}
