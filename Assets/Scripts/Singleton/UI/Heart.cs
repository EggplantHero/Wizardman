using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Sprite full;
    public Sprite empty;
    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Fill()
    {
        image.sprite = full;
    }
    public void Empty()
    {
        image.sprite = empty;
    }
}
