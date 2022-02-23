using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : GroundItem<ItemObject>
{
    private AudioManager audioManager;
    public SoundType pickupSFX;

    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "PlayerBody")
        {
            PlaySFX();
            Player player = collider.gameObject.GetComponentInParent<Player>();
            player.inventory.AddItem(new Item(itemObject), 1);
            Destroy(this.gameObject);
        }
    }

    public void PlaySFX()
    {
        audioManager.Play(pickupSFX, audioManager.sfx_interactables_track);
    }
}
