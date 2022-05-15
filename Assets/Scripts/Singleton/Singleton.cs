using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Main { get; private set; }
    public AudioManager AudioManager { get; private set; }
    private void Awake()
    {
        if (Main != null && Main != this)
        {
            Destroy(this);
            return;
        }
        Main = this;

        //Components
        AudioManager = GetComponentInChildren<AudioManager>();
    }

}
