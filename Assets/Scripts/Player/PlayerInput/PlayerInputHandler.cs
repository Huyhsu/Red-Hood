using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private float inputHoldTime = 0.2f;
    
    private PlayerInput _playerInput;
    
    private Vector2 _rawMovementInput;

    private float _jumpInputStartTime;
    private float _slideInputStartTime;
    
    public int NormalizedXInput { get; private set; }
    public int NormalizedYInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool SlideInput { get; private set; }
    public bool SlideInputStop { get; private set; }
    
    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckSlideInputHoldTime();
    }

    #region w/ Move

    public void OnMovementInput(InputAction.CallbackContext context)
    {
        _rawMovementInput = context.ReadValue<Vector2>();
        NormalizedXInput = Mathf.RoundToInt(_rawMovementInput.x);
        NormalizedYInput = Mathf.RoundToInt(_rawMovementInput.y);
    } 

    #endregion

    #region w/ Jump

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            _jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void UseJumpInput() => JumpInput = false;

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= _jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }    

    #endregion

    #region w/ Slide

    public void OnSlideInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SlideInput = true;
            SlideInputStop = false;
            _slideInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            SlideInputStop = true;
        }
    }

    public void UseSlideInput() => SlideInput = false;

    private void CheckSlideInputHoldTime()
    {
        if (Time.time >= _slideInputStartTime + inputHoldTime)
        {
            SlideInput = false;
        }
    }
    
    #endregion

}
