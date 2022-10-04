using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

abstract public class ActionState
{
    static public Tag tagging = new Tag();
    static public Idle idling = new Idle();
    static public Defense defending = new Defense();

    abstract public void Update(PlayerMovement movement);
    abstract public void HandleInput(PlayerMovement movement);

    abstract public void Animate(ref Animator animator);

    public void ResetAllAnimationTrigger(ref Animator animator)
    {
        foreach (var boolian in animator.parameters)
        {
            if (boolian.type == AnimatorControllerParameterType.Bool)
            {
                animator.ResetTrigger(boolian.name);
            }
        }
    }
}

public class Idle : ActionState
{
    override public void Update(PlayerMovement movement)
    {
    }
    override public void HandleInput(PlayerMovement movement)
    {
        ref var state = ref movement.GetReferActionState();

        if(Input.GetKeyDown(KeyCode.Q))
        {
            state = tagging;
            return;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            state = defending;
            return;
        }
    }

    override public void Animate(ref Animator animator)
    {
        animator.SetTrigger("Idle");
    }
}

public class Tag : ActionState
{
    override public void Update(PlayerMovement movement)
    {
    }
    override public void HandleInput(PlayerMovement movement)
    {
        ref var state = ref movement.GetReferActionState();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            state = idling;
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            state = defending;
            return;
        }
    }

    override public void Animate(ref Animator animator)
    {
        animator.SetTrigger("Tag");
    }
}

public class Defense : ActionState
{
    override public void Update(PlayerMovement movement)
    {
    }
    override public void HandleInput(PlayerMovement movement)
    {
        ref var state = ref movement.GetReferActionState();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            state = tagging;
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            state = idling;
            return;
        }
    }

    override public void Animate(ref Animator animator)
    {
        animator.SetTrigger("Defense");
    }
}
