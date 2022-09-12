using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAmp : Clock
{
    public float speed;

    public float ClockHandSpeed;

    public float gravity;

    private float minuteAngle;
    private float hourAngle;

    public override void Awake()
    {

    }

    public void Update()
    {
        minuteAngle -= 360 * ClockHandSpeed;
        hourAngle -= 30 * ClockHandSpeed;
        minuteHand.Rotate(minuteAngle);
        hourHand.Rotate(hourAngle);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Entity entity = col.transform.GetComponentInParent<Entity>();
        if (entity == null) return;

        List<string> names = new List<string>() { "Head", "Feet", "Front", "Back" };

        if (names.Contains(col.name)) return;

        if (col.name == "PlayerBody")
        {
            entity.movement.movementSpeed = speed;
            entity.movement.SetGravity(gravity);
        }
        else
        {
            if (entity.movement == null) return;
            entity.rbody.velocity *= speed;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "PlayerBody")
        {
            Entity entity = col.transform.GetComponentInParent<Entity>();
            entity.movement.ResetMovementSpeed();
            entity.movement.ResetGravity(); ;
        }
    }
}
