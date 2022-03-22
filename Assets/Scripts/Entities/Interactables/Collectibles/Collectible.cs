using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : GroundItem<ItemObject>
{

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "PlayerBody")
        {
            PlaySFX();
            Player player = collider.gameObject.GetComponentInParent<Player>();
            player.inventory.AddItem(new Item(itemObject), 1);
            Destroy(this.gameObject);
        }
    }
}
