using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    public static int gravityDirection = 1;
    public int facingDirectionX { get; private set; }
    private int facingDirectionY;
    public float movementSpeed;
    public float defaultGravityScale;
    private float terminalVelocity;

    protected override void Awake()
    {
        base.Awake();

        facingDirectionX = 1;
        facingDirectionY = 1;
        terminalVelocity = 25f;
    }

    protected void Start()
    {
        entity.rbody.gravityScale = defaultGravityScale * gravityDirection;
    }

    protected void FixedUpdate()
    {
        if (entity.rbody.velocity.magnitude > terminalVelocity)
        {
            entity.rbody.velocity = entity.rbody.velocity.normalized * terminalVelocity;
        }
        if (gravityDirection != facingDirectionY)
        {
            entity.rbody.gravityScale = defaultGravityScale * gravityDirection;
            facingDirectionY *= -1;
            FlipY();
        }
    }

    public static void InvertGravity()
    {
        gravityDirection *= -1;
    }

    #region Set Functions

    public void SetVelocityX(float speed)
    {
        entity.rbody.velocity = new Vector2(speed, entity.rbody.velocity.y);
    }
    public void SetVelocityY(float speed)
    {
        entity.rbody.velocity = new Vector2(entity.rbody.velocity.x, speed);
    }

    public void AddKnockback(Vector2 direction, float strength)
    {
        Vector2 knockbackdir = (direction.normalized * strength);
        if (entity.collisionSenses.grounded)
        {
            knockbackdir.y = strength;
        }
        entity.rbody.velocity = knockbackdir;
    }

    public void SetGravity(float value)
    {
        entity.rbody.gravityScale = value;
    }

    public void ResetGravity()
    {
        entity.rbody.gravityScale = defaultGravityScale * gravityDirection;
    }
    public void SetMass(float value)
    {
        entity.rbody.mass = value;
    }

    public void TurnAroundX()
    {
        FlipX(-facingDirectionX);
    }

    public void FlipX(float input)
    {
        if (input != 0 && input != facingDirectionX)
        {
            facingDirectionX *= -1;
            entity.rbody.transform.Rotate(0, 180, 0);
        }
    }
    public void FlipY()
    {
        // facingDirectionY *= -1;
        entity.rbody.transform.Rotate(180, 0, 0);
    }
    #endregion
}
