using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpGroundedState : PlayerAbilityState
{
    public PlayerJumpGroundedState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Core.Movement.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (IsExitingState) return;

        if (IsAnimationFinished)
        {
            StateMachine.ChangeState(Player.JumpState);
        }
    }
}
