using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlideState : PlayerAbilityState
{
    #region w/ Slide
    
    private float _lastSlideTime;

    public bool CanSlide() => Time.time >= _lastSlideTime + PlayerData.slideCooldown;
    
    #endregion
    
    public PlayerSlideState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        Player.InputHandler.UseSlideInput();
        // Core.Movement.SetVelocityX(Core.Movement.FacingDirection * PlayerData.slideVelocity);
        // IsAbilityDone = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (IsExitingState) return;
        JumpInput = Player.InputHandler.JumpInput;
        
        Core.Movement.SetVelocityX(Core.Movement.FacingDirection * PlayerData.slideVelocity);
        
        if (JumpInput && Player.JumpState.CanJump())
        {
            IsAbilityDone = true;
            _lastSlideTime = Time.time;
            StateMachine.ChangeState(Player.JumpState);
        }
        else if (Time.time >= StartTime + PlayerData.slideTime)
        {
            IsAbilityDone = true;
            _lastSlideTime = Time.time;
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
