using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public ClockHand minuteHand;
    public ClockHand hourHand;
    public ClockHand secondHand;

    public void Awake()
    {
        Display(false);
    }

    public void ResetAll()
    {
        minuteHand.Reset();
        secondHand.Reset();
        hourHand.Reset();
    }

    public void Display(bool value)
    {
        this.gameObject.SetActive(value);
    }

}
