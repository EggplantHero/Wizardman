using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    [SerializeField] private Collider2D bodyCollider;
    [SerializeField] private Collider2D feetCollider;
    [SerializeField] private Collider2D hitbox;
    [SerializeField] private Collider2D headCollider;
    [SerializeField] private Collider2D frontCollider;
    [SerializeField] private Collider2D backCollider;

    [SerializeField] private PhysicsMaterial2D zeroFriction;
    [SerializeField] private PhysicsMaterial2D bouncy;

    public void SetMaterial(PhysicsMaterial2D mat)
    {
        bodyCollider.sharedMaterial = mat;
        feetCollider.sharedMaterial = mat;
    }

    public PhysicsMaterial2D ZeroFriction
    {
        get => zeroFriction;
    }
    public PhysicsMaterial2D Bouncy
    {
        get => bouncy;
    }

    public bool grounded
    {
        get => feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    public bool facingWall
    {
        get => frontCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

    }
    public bool backToWall
    {
        get => backCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
    public bool touchingLadder
    {
        get => bodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"));
    }
    public bool touchingPlayer
    {
        get => bodyCollider.IsTouchingLayers(LayerMask.GetMask("Player"));
    }

    public Collider2D BodyCollider
    {
        get => bodyCollider;
    }
    public Collider2D FeetCollider
    {
        get => feetCollider;
    }
    public Collider2D HeadCollider
    {
        get => headCollider;
    }
    public Collider2D Hitbox
    {
        get => hitbox;
    }

}
