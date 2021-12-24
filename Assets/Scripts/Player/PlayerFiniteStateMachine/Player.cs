using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables

    [SerializeField] private PlayerData playerData;

    public PlayerData PlayerData
    {
        get => playerData;
        private set => playerData = value;
    }
    public PlayerStateMachine StateMachine { get; private set; }
    
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerJumpGroundedState JumpGroundedState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    

    #endregion

    #region Components

    public Core Core { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Animator Animator { get; private set; }
    // public BoxCollider2D MovementBoxCollider2D { get; private set; }    

    #endregion

    #region Unity Callback Functions

    private void Awake()
    {
        Core = GetComponentInChildren<Core>();
        
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, "idle");
        MoveState = new PlayerMoveState(this, "move");
        JumpState = new PlayerJumpState(this, "inAir");
        JumpGroundedState = new PlayerJumpGroundedState(this, "jumpGrounded");
        InAirState = new PlayerInAirState(this, "inAir");
        LandState = new PlayerLandState(this, "land");

    }

    private void Start()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        Animator = GetComponent<Animator>();
        // MovementBoxCollider2D = GetComponent<BoxCollider2D>();
        
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion

    #region Other Functions

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    #endregion
}
