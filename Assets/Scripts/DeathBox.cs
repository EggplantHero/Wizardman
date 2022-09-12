using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "PlayerBody")
        {
            Entity entity = col.gameObject.GetComponentInParent<Entity>();
            entity.combat.Damage(1, DamageType.DMG_Physical);

            PlayerSpawn playerSpawn = FindObjectOfType<PlayerSpawn>();
            playerSpawn.RespawnPlayer();
        }
    }
}
