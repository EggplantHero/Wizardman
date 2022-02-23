using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrostState : PlayerConjureState
{
    public PlayerFrostState(Player player, string animation) : base(player, animation)
    {
    }

    Spell icecube;
    public override void OnEnter()
    {
        base.OnEnter();
        ConjureIcecube();
        player.movement.SetVelocityX(0);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    void ConjureIcecube()
    {
        Vector3 spawnPoint = player.transform.position + new Vector3(player.movement.facingDirectionX * 1.5f, Movement.gravityDirection * 2, 0);
        Collider2D overlap = Physics2D.OverlapPoint(spawnPoint);
        if (overlap == null || overlap.isTrigger == true)
        {
            if (icecube)
            {
                GameObject.Destroy(icecube.gameObject);
            }
            icecube = GameObject.Instantiate(playerData.icecube, spawnPoint, Quaternion.identity);
        }
    }

    public override void Update()
    {
        base.Update();
    }

}
