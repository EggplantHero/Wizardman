using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedState : State
{
    public Lock lok;
    public UnlockedState(Lock entity, string animation) : base(entity, animation)
    {
        this.lok = entity;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        lok.OpenLock();
    }

    public override void Update()
    {
        if (lok.unlockOnly) return;
        base.Update();

        foreach (var key in lok.keys)
        {
            if (!key.On)
            {
                lok.CloseLock();
            }
        }
    }
}
