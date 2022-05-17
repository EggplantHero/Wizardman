using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedSpell : MonoBehaviour
{
    private Image image;
    private SpellScrollObject equippedSpell;
    public Sprite empty;
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetScroll(SpellScrollObject scroll)
    {
        equippedSpell = scroll;
        if (equippedSpell.uiDisplay)
        {
            image.sprite = equippedSpell.uiDisplay;
        }
        else { image.sprite = empty; }
    }
}
