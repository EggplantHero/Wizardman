using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : Entity
{
    public Player player;
    public UIState UIState;
    public bool paused;
    public GameObject levelSelect;

    public override void Awake()
    {
        base.Awake();
        UIState = new UIState(this, "Idling");
        paused = false;
        levelSelect = GetComponentInChildren<LevelSelectScreen>().gameObject;
        levelSelect.SetActive(false);
    }

    private void Start()
    {
        stateMachine.Initialize(UIState);
        Debug.Log(stateMachine.CurrentState);
    }

}
