using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int XInput;
    protected int YInput;
    protected bool JumpInput;
    protected bool SlideInput;

    private bool _isGrounded;
    
    public PlayerGroundedState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        _isGrounded = Core.CollisionSenses.Ground;
    }

    public override void Enter()
    {
        base.Enter();
        Player.JumpState.ResetAmountOfJumpsLeft();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        XInput = Player.InputHandler.NormalizedXInput;
        YInput = Player.InputHandler.NormalizedYInput;
        JumpInput = Player.InputHandler.JumpInput;
        SlideInput = Player.InputHandler.SlideInput;

        if (JumpInput && Player.JumpState.CanJump())
        {
            StateMachine.ChangeState(Player.JumpGroundedState);
        }
        else if (SlideInput && Player.SlideState.CanSlide())
        {
            StateMachine.ChangeState(Player.SlideState);
        }
        else if (!_isGrounded)
        {
            Player.InAirState.StartCoyoteTime();
            StateMachine.ChangeState(Player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
