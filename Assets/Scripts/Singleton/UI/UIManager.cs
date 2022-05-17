using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [HideInInspector] public HealthBar Health;
    [HideInInspector] public LevelSelectScreen LevelSelectScreen;
    [HideInInspector] public EquippedSpell EquippedSpell;
    private bool paused;
    private float savedTimescale;

    public void Awake()
    {
        Health = GetComponentInChildren<HealthBar>();
        LevelSelectScreen = GetComponentInChildren<LevelSelectScreen>();
        EquippedSpell = GetComponentInChildren<EquippedSpell>();
        LevelSelectScreen.Hide();
    }

    public void PauseGame()
    {
        if (paused)
        {
            if (savedTimescale == 0)
                Time.timeScale = 1;
            else
                Time.timeScale = savedTimescale;
            LevelSelectScreen.Hide();
        }
        else
        {
            savedTimescale = Time.timeScale;
            Time.timeScale = 0;
            LevelSelectScreen.Show();
        }
        paused = !paused;
    }

}
