using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class CollisionSenses : CoreComponent
{
    #region Check Transforms

    public Transform GroundCheck
    {
        get => GenericNotImplementedError<Transform>.TryGet(groundCheck, Core.transform.parent.name);
        private set => groundCheck = value;
    }

    public float GroundCheckRadius
    {
        get => groundCheckRadius;
        private set => groundCheckRadius = value;
    }

    public LayerMask WhatIsGround
    {
        get => whatIsGround;
        private set => whatIsGround = value;
    }
    
    [SerializeField] private Transform groundCheck;

    [SerializeField] private float groundCheckRadius;

    [SerializeField] private LayerMask whatIsGround;

    #endregion

    public bool Ground => Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);
}
