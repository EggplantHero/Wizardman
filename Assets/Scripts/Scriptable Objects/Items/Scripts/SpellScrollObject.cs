using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New SpellScroll Object", menuName = "Inventory System/Items/SpellScroll")]


public class SpellScrollObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.SpellScroll;
    }

    public SpellType spell;
}
