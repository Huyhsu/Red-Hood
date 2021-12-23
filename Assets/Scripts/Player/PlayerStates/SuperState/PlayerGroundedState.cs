using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int XInput;
    protected int YInput;

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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
