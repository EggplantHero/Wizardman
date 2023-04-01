using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
        Debug.Log(col.collider.name);

        if (col.gameObject.name == "Breakable")
        {
            Singleton.Main.AudioManager.Play(SoundType.SFX_FireballExplosion);
            player.movement.SetVelocityY(-playerData.lightningSpeed);
            DestroyTerrain(col, player.transform.position, 1f);
            return;
        };


        player.movement.ResetGravity();
        if (Movement.gravityDirection == -1)
        {
            player.movement.FlipY();
        }



        Singleton.Main.AudioManager.Play(SoundType.SFX_LightningBoom);
        CinemachineShake.Instance.ShakeCamera(5f, .2f);

        if (col.gameObject.name == "Spring")
        {
            player.movement.SetVelocityY(playerData.lightningSpeed * 2);
            ExitState();
            return;
        }

        player.animator.Play("LightningLand");
    }

    public override void Update()
    {
        base.Update();
        //for security, prevents moving up while in lightning state
        if (player.rbody.velocity.y > 0)
        {
            player.movement.SetVelocityY(0);
            player.movement.ResetGravity();
            if (Movement.gravityDirection == -1)
            {
                player.movement.FlipY();
            }
            Singleton.Main.AudioManager.Play(SoundType.SFX_LightningBoom);
            CinemachineShake.Instance.ShakeCamera(5f, .2f);
            player.animator.Play("LightningLand");
            ExitState();
        }
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


    public void DestroyTerrain(Collision2D col, Vector3 explosionLocation, float radius)
    {
        Tilemap[] tilemaps = col.gameObject.GetComponentsInChildren<Tilemap>();
        for (int x = -(int)radius; x < radius; x++)
        {
            for (int y = -(int)radius; y < radius; y++)
            {
                foreach (Tilemap terrain in tilemaps)
                {
                    Vector3Int tilePos = terrain.WorldToCell(explosionLocation + new Vector3(x, y, 0));
                    if (terrain.GetTile(tilePos) != null)
                    {
                        terrain.SetTile(tilePos, null);
                    }
                }
            }
        }
    }
}
