using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Entity
{
    public Switch[] keys;
    public LockedState LockedState { get; private set; }
    public UnlockedState UnlockedState { get; private set; }
    public bool unlockOnly;
    public bool locked;

    public void OpenLock()
    {
        locked = false;
    }
    public void CloseLock()
    {
        locked = true;
    }

}
