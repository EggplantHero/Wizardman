using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScroll : GroundItem<SpellScrollObject>
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
            SpellScrollObject switcheroo;
            switcheroo = itemObject;
            itemObject = player.inventory.equippedSpell;
            player.inventory.EquipSpell(switcheroo);
            player.castAvailable = true;
            if (itemObject.spell == SpellType.SPELL_None)
            {
                Destroy(this.gameObject);
            }
            else
            {
                ReRender();
            }
        }
    }

    public void PlaySFX()
    {
        audioManager.Play(pickupSFX, audioManager.sfx_interactables_track);
    }

}
