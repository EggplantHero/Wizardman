using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : CoreComponent
{
    public State CurrentState { get; private set; }

    public void Initialize(State startingState)
    {
        CurrentState = startingState;
        CurrentState.OnEnter();
    }

    public void SetState(State newState)
    {
        if (newState != CurrentState)
        {
            CurrentState.OnExit();
            CurrentState = newState;
            CurrentState.OnEnter();
        }
    }
}
