using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightningState : PlayerCastState
{
    public PlayerLightningState(Player player, string animation) : base(player, animation)
    {
    }

    public Entity lightning;

    public override void OnEnter()
    {
        base.OnEnter();

        if (player.collisionSenses.grounded && Movement.gravityDirection == 1)
        {
            player.animator.Play("Casting");
            return;
        }
        player.combat.SetImmune(true);
        lightning = GameObject.Instantiate(playerData.lightning, player.transform.position, Quaternion.identity).GetComponent<Entity>();
        lightning.transform.SetParent(player.transform);
        lightning.transform.localPosition = Vector3.zero;
        if (Movement.gravityDirection == -1)
        {
            player.movement.FlipY();
        }
        player.movement.SetVelocityX(0);
        player.movement.SetGravity(0);
        player.movement.SetVelocityY(-playerData.lightningSpeed);

    }

    public override void OnCast(float input)
    {
        player.movement.ResetGravity();
        ExitState();
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col);
        base.OnCollisionEnter2D(col);
        player.movement.ResetGravity();
        if (Movement.gravityDirection == -1)
        {
            player.movement.FlipY();
        }

        Singleton.Main.AudioManager.Play(SoundType.SFX_LightningBoom);
        player.animator.Play("LightningLand");
        CinemachineShake.Instance.ShakeCamera(5f, .2f);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void ExitState()
    {
        if (lightning)
        {
            GameObject.Destroy(lightning.gameObject);
        }
        player.combat.SetImmune(false);

        base.ExitState();
    }
}
