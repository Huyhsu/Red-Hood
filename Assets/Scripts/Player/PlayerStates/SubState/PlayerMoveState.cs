using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Core.Movement.CheckIfShouldFlip(XInput);
        Core.Movement.SetVelocityX(XInput * PlayerData.movementVelocity);
        if (!IsExitingState)
        {
            if (XInput == 0)
            {
                StateMachine.ChangeState(Player.IdleState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
