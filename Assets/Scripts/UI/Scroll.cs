using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public UI ui;
    private Image image;
    private SpellScrollObject scroll;
    public Sprite empty;
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        scroll = ui.player.inventory.equippedSpell;
        if (scroll.uiDisplay)
        {
            image.sprite = scroll.uiDisplay;
        }
        else { image.sprite = empty; }
    }
}
