using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIState : State
{
    private UI ui;
    private float savedTimescale;
    public UIState(UI entity, string animation) : base(entity, animation)
    {
        this.ui = entity;
    }

    public override void OnPause(float input)
    {
        base.OnPause(input);

        if (ui.paused)
        {
            if (savedTimescale == 0)
                Time.timeScale = 1;
            else
                Time.timeScale = savedTimescale;
            ui.levelSelect.SetActive(false);
        }
        else
        {
            savedTimescale = Time.timeScale;
            Time.timeScale = 0;
            ui.levelSelect.SetActive(true);
        }
        ui.paused = !ui.paused;
    }
}
