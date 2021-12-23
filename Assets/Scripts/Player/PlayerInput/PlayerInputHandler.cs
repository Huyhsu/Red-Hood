using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput _playerInput;
    
    private Vector2 _rawMovementInput;
    
    public int NormalizedXInput { get; private set; }
    public int NormalizedYInput { get; private set; }
    
    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }
    
    public void OnMovementInput(InputAction.CallbackContext context)
    {
        _rawMovementInput = context.ReadValue<Vector2>();
        
        NormalizedXInput = Mathf.RoundToInt(_rawMovementInput.x);
        NormalizedYInput = Mathf.RoundToInt(_rawMovementInput.y);
        
        // if(Mathf.Abs(_rawMovementInput.x) > 0.5f)
        // {
        //     NormalizedXInput = (int)(_rawMovementInput * Vector2.right).normalized.x;
        // }
        // else
        // {
        //     NormalizedXInput = 0;
        // }
        //
        // if(Mathf.Abs(_rawMovementInput.y) > 0.5f)
        // {
        //     NormalizedYInput = (int)(_rawMovementInput * Vector2.up).normalized.y;
        // }
        // else
        // {
        //     NormalizedYInput = 0;
        // }
        
    
    }
}
