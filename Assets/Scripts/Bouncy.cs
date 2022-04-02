using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    private Player player;
    [SerializeField] private float bounceHeight;
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (GetComponentInChildren<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            player = col.gameObject.GetComponentInParent<Player>();
            Debug.Log(col.collider);
            Debug.Log(player.collisionSenses.FeetCollider);
            if (col.collider == player.collisionSenses.FeetCollider)
            {
                player.movement.SetVelocityY(bounceHeight * Movement.gravityDirection);
            }
        }
    }
}