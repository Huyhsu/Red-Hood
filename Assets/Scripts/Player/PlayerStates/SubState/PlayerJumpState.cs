using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    #region w/ Jump

    private int amountOfJumpsLeft;
    
    public bool CanJump() => amountOfJumpsLeft > 0;
    public void ResetAmountOfJumpsLeft() => amountOfJumpsLeft = Player.PlayerData.amountOfJumps;
    public void DecreaseAmountOfJumpsLeft() => amountOfJumpsLeft--;    

    #endregion

    public PlayerJumpState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
        amountOfJumpsLeft = Player.PlayerData.amountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();
        Player.InputHandler.UseJumpInput();
        Core.Movement.SetVelocityY(PlayerData.jumpVelocity);
        IsAbilityDone = true;
        DecreaseAmountOfJumpsLeft();
        Player.InAirState.SetIsJumping();
    }
}
