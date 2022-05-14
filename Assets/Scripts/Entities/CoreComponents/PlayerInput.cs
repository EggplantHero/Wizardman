using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : CoreComponent
{

    public float movementInput { get; private set; }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            float input = context.ReadValue<float>();
            movementInput = input;
            entity.stateMachine.CurrentState.OnMove(input);
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            float input = context.ReadValue<float>();
            entity.stateMachine.CurrentState.OnJump(input);
        }
    }
    public void OnCast(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            float input = context.ReadValue<float>();
            entity.stateMachine.CurrentState.OnCast(input);
        }
    }
    public void OnClimb(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<float>();
        entity.stateMachine.CurrentState.OnClimb(input);
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            float input = context.ReadValue<float>();
            entity.stateMachine.CurrentState.OnPause(input);
        }
    }
}
