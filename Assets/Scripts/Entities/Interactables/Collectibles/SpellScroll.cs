using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScroll : GroundItem<SpellScrollObject>
{
    public int equipSpellCooldown;

    public bool spellEquippable;

    void Awake()
    {
        equipSpellCooldown = 1;
        spellEquippable = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!spellEquippable) return;

        if (collider.name == "PlayerBody")
        {
            PlaySFX();
            Player player = collider.gameObject.GetComponentInParent<Player>();
            SpellScrollObject switcheroo;
            switcheroo = itemObject;
            itemObject = player.inventory.equippedSpell;
            player.inventory.EquipSpell(switcheroo);
            Singleton.Main.UIManager.EquippedSpell.SetScroll(switcheroo);
            player.castAvailable = true;
            if (itemObject.spell == SpellType.SPELL_None)
            {
                Destroy(this.gameObject);
            }
            else
            {
                ReRender();
            }
            StartCoroutine(Cooldown());
        }

    }

    IEnumerator Cooldown()
    {
        spellEquippable = false;
        yield return new WaitForSeconds(equipSpellCooldown);
        spellEquippable = true;
    }

}
