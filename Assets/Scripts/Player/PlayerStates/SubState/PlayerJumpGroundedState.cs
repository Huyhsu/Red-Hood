using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpGroundedState : PlayerState
{
    public PlayerJumpGroundedState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (IsAnimationFinished)
        {
            StateMachine.ChangeState(Player.JumpState);
        }
    }
}
