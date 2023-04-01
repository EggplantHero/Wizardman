using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : Entity
{
    public float Power;

    public float DecompressedTime;

    public override void OnTriggerEnter2D(Collider2D col)
    {
        Entity entity = col.gameObject.GetComponentInParent<Entity>();
        if (entity == null) return;
        if (col.name != "Feet" && col.name != "PlayerFeet") return;

        float speed = entity.rbody.velocity.y;
        if (speed < Power) speed = Power;
        entity.movement.SetVelocityY(speed);

        StartCoroutine(Decompress());
    }

    IEnumerator Decompress()
    {
        animator.Play("Triggered");
        yield return new WaitForSeconds(DecompressedTime);
        animator.Play("Idle");
    }
}
