using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.TextCore.Text;
using UnityEngine;

abstract public class MoveState
{
    static public Stand standing = new Stand();
    static public Walk walking = new Walk();
    static public Run running = new Run();
    protected Vector3 direction;
 
    public MoveState() { }

    abstract public void Update(PlayerMovement movement);
    abstract public void HandleInput(ref MoveState state, Transform transform);
    abstract public void Move(ref Rigidbody rigid, Transform transform);
    abstract public void Rotate(Transform transform);
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

public class Stand : MoveState
{
    private float rotationSpeed = 10f;

    override public void Update(PlayerMovement movement)
    {
        Initialize();
    }
    override public void HandleInput(ref MoveState state, Transform transform)
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            state = walking;
            return;
        }
    }

    private void Initialize()
    {

    }
    override public void Move(ref Rigidbody rigid, Transform transform)
    {
        rigid.velocity = Vector3.zero;
    }
    // Rotate by mouse position.
    override public void Rotate(Transform transform)
    {
        Vector3 worldPosition;
        Vector3 direction;
        Quaternion toRotation;
        Ray     ray;
        Plane   plane;
        float   distance;

        plane = new Plane(Vector3.up, 0);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
            direction = worldPosition - transform.position;

            toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);   
        }
    }
    override public void Animate(ref Animator animator)
    {
        ResetAllAnimation(ref animator);
        animator.SetTrigger("Stand");
    }
}

public class Walk : MoveState
{
    private float frontSpeed = 100f;
    private float rotationSpeed = 10f;
    bool isLeft = false;
    bool isRight = false;
    bool isForward = false;
    bool isBackward = false;

    override public void Update(PlayerMovement movement)
    {
        Initialize();
    }
    override public void HandleInput(ref MoveState state, Transform transform)
    {
        if(!Input.anyKey)
        {
            state = standing;
            return;
        }
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            state = running;
            return;
        }

        if(Input.GetKey(KeyCode.W))
        {
            isForward = true;
            direction += transform.forward;
        }
        if(Input.GetKey(KeyCode.S))
        {
            isBackward = true;
            direction -= transform.forward;
        }
        if(Input.GetKey(KeyCode.D))
        {
            isRight = true;
            direction += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            isLeft = true;
            direction -= transform.right;
        }
    }

    private void Initialize()
    {

    }
    override public void Move(ref Rigidbody rigid, Transform transform)
    {
        rigid.velocity = direction.normalized * frontSpeed * Time.fixedDeltaTime;

        direction = Vector3.zero;
    }
    override public void Rotate(Transform transform)
    {
        Vector3 worldPosition;
        Vector3 direction;
        Quaternion toRotation;
        Ray ray;
        Plane plane;
        float distance;

        plane = new Plane(Vector3.up, 0);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
            direction = worldPosition - transform.position;

            toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
    override public void Animate(ref Animator animator)
    {
        ResetAllAnimation(ref animator);
        
        if(isForward ||
          (isForward && isRight )||
          (isForward && isLeft))
        {
            animator.SetTrigger("FrontWalk");
        }
        else if(isBackward ||
               (isBackward && isRight)||
               (isBackward && isLeft))
        {
            animator.SetTrigger("BackWalk");
        }

        if(!isForward && !isBackward)
        {
            if(isLeft)
            {
                animator.SetTrigger("LeftWalk");
            }

            if(isRight)
            {
                animator.SetTrigger("RightWalk");
            }
        }

        isForward = false;
        isBackward = false;
        isLeft = false;
        isRight = false;
    }
}

public class Run : MoveState
{
    private float speed = 200f;
    private float rotationSpeed = 5f;

    override public void Update(PlayerMovement movement)
    {
        Initialize();
    }
    override public void HandleInput(ref MoveState state, Transform transform)
    {
        if(!Input.anyKey)
        {
            state = standing;
            return;
        }
        if(!Input.GetKey(KeyCode.LeftShift) &&
           (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) 
           ))
        {
            state = walking;
            return;
        }
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            state = walking;
            return;
        }
        if (Input.GetKey(KeyCode.W) &&
            Input.GetKey(KeyCode.A) &&
            Input.GetKey(KeyCode.LeftShift))
        {
            state = walking;
            return;
        }
        if (Input.GetKey(KeyCode.W) &&
            Input.GetKey(KeyCode.D) &&
            Input.GetKey(KeyCode.LeftShift))
        {
            state = walking;
            return;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            direction += transform.forward;
        }
    }

    private void Initialize()
    {

    }
    override public void Move(ref Rigidbody rigid, Transform transform)
    {
        rigid.velocity = direction.normalized * speed * Time.fixedDeltaTime;

        direction = Vector3.zero;
    }
    override public void Rotate(Transform transform)
    {
        Vector3 worldPosition;
        Vector3 direction;
        Quaternion toRotation;
        Ray ray;
        Plane plane;
        float distance;

        plane = new Plane(Vector3.up, 0);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
            direction = worldPosition - transform.position;

            toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
    override public void Animate(ref Animator animator) 
    {
        ResetAllAnimation(ref animator);
        animator.SetTrigger("Run");
    }
}
