using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Core Core;
    
    protected Player Player;
    protected PlayerStateMachine StateMachine;
    protected PlayerData PlayerData;

    protected bool IsAnimationFinished;
    protected bool IsExitingState;

    protected float StartTime;

    private string _animationBoolName;

    protected PlayerState(Player player, string animationBoolName)
    {
        Player = player;
        _animationBoolName = animationBoolName;
        Core = player.Core;
        StateMachine = player.StateMachine;
        PlayerData = player.PlayerData;
    }
    
    public virtual void DoCheck() { }

    public virtual void Enter()
    {
        DoCheck();
        Player.Animator.SetBool(_animationBoolName,true);
        StartTime = Time.time;
        IsAnimationFinished = false;
        IsExitingState = false;
    }

    public virtual void Exit()
    {
        Player.Animator.SetBool(_animationBoolName, false);
        IsExitingState = true;
    }
    
    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate()
    {
        DoCheck();
    }
    
    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => IsAnimationFinished = true;
}
