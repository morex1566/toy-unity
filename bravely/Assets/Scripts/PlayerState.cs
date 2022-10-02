using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

abstract public class MoveState
{
    static public Idle idling = new Idle();
    static public Walk walking = new Walk();
    static public Run running = new Run();
    public float horizontal;
    public float vertical;

    public MoveState() { }

    abstract public void HandleInput(ref MoveState state);
    abstract public void Move(ref Rigidbody rigid);
    abstract public void Animate(ref Animator animator);

    public void ResetAllAnimation(ref Animator animator)
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

public class Idle : MoveState
{
    override public void HandleInput(ref MoveState state)
    {
        if (Input.GetAxis("Horizontal") != 0 ||
            Input.GetAxis("Vertical") != 0)
        {
            state = walking;
            return;
        }
    }
    override public void Move(ref Rigidbody rigid)
    {
        rigid.velocity = Vector3.zero;
    }
    override public void Animate(ref Animator animator)
    {
        ResetAllAnimation(ref animator);
        animator.SetTrigger("Idle");
    }

    void test()
    {
        Debug.Log("walking");
    }
}

public class Walk : MoveState
{
    private float speed = 100f;

    override public void HandleInput(ref MoveState state)
    {
        if (Input.GetAxis("Horizontal") != 0 ||
            Input.GetAxis("Vertical") != 0)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                state = running;
                return;
            }
            else // walking
            {
                return;
            }
        }

        state = idling;
    }
    override public void Move(ref Rigidbody rigid)
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),
                                        0,
                                        Input.GetAxis("Vertical")).normalized;

        rigid.velocity = direction * speed * Time.fixedDeltaTime;
    }
    override public void Animate(ref Animator animator)
    {
        ResetAllAnimation(ref animator);
        animator.SetTrigger("Walk");
    }

    void test()
    {
        Debug.Log("idling");
    }
}

public class Run : MoveState
{
    private float speed = 200f;

    override public void HandleInput(ref MoveState state)
    {
        if (Input.GetAxis("Horizontal") != 0 ||
            Input.GetAxis("Vertical") != 0)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                return;
            }
            else
            {
                state = walking;
                return;
            }
        }

        state = idling;
    }

    override public void Move(ref Rigidbody rigid)
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),
                                        0,
                                        Input.GetAxis("Vertical")).normalized;

        rigid.velocity = direction * speed * Time.fixedDeltaTime;
    }
    override public void Animate(ref Animator animator) 
    {
        ResetAllAnimation(ref animator);
        animator.SetTrigger("Run");
    }
}
