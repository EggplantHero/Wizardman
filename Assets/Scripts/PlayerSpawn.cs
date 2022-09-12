using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Player player;
    void Awake()
    {
        RespawnPlayer();
        player.inventory.Clear();
    }

    public void RespawnPlayer()
    {
        player.transform.position = transform.position;
    }
}
