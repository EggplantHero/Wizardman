using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Entity
{
    public SwitchOnState OnState { get; private set; }
    public SwitchOffState OffState { get; private set; }
    public bool On { get; private set; }

    public void TurnOn()
    {
        On = true;
    }
    public void TurnOff()
    {
        On = false;
    }


}
