using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHand : MonoBehaviour
{
    public float angle;

    public void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        angle = 90;
        Rotate(angle);
    }

    public void Rotate(float value)
    {
        angle = value;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }



}
