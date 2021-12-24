using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool IsAbilityDone;
    protected bool IsGrounded;
    
    public PlayerAbilityState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        IsGrounded = Core.CollisionSenses.Ground;
    }

    public override void Enter()
    {
        base.Enter();
        IsAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (IsAbilityDone)
        {
            if (IsGrounded && Core.Movement.CurrentVelocity.y < 0.01f)
            {
                StateMachine.ChangeState(Player.IdleState);
            }
            else
            {
                StateMachine.ChangeState(Player.InAirState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
