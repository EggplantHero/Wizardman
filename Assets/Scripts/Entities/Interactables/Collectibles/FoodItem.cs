using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : GroundItem<FoodObject>
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "PlayerBody")
        {
            PlaySFX();
            Player player = collider.gameObject.GetComponentInParent<Player>();
            player.combat.Heal(itemObject.restoreHealthValue);
            Singleton.Main.UIManager.Health.HandleDamage(player.combat.CurrentHealth);
            Destroy(this.gameObject);
        }

    }
}
