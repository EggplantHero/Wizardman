using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    private Player player;
    public Sprite full;
    public Sprite empty;
    [HideInInspector] public int index;
    private Image image;
    private int previousHealth;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Start()
    {
        previousHealth = player.combat.CurrentHealth;
    }

    void Update()
    {
        if (player.combat.CurrentHealth == previousHealth)
        {
            return;
        }
        if (player.combat.CurrentHealth < index + 1)
        {
            Empty();
        }
        else
        {
            Fill();
        }
        previousHealth = player.combat.CurrentHealth;
    }

    public void Fill()
    {
        image.sprite = full;
    }
    public void Empty()
    {
        image.sprite = empty;
    }

    public void Setup(int index, Player player)
    {
        this.index = index;
        this.player = player;
    }
}
