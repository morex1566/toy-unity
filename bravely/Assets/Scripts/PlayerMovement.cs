using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private MoveState moveState;
    private ActionState actionState;
    private Animator animator;
    private Rigidbody rigid;


    // Start is called before the first frame update
    void Start()
    {
        moveState = MoveState.standing;
        actionState = ActionState.idling;

        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        InnerUpdate();
        Move();
        Rotate();
        Animate();
    }
    virtual public void Move()
    {
        moveState.Move(ref rigid, transform);
    }
    virtual public void Rotate()
    {
        moveState.Rotate(transform);
    }
    virtual public void Animate()
    {
        moveState.Animate(ref animator);
        actionState.Animate(ref animator);
    }
    virtual public void InnerUpdate()
    {
        moveState.Update(this);
        actionState.Update(this);
    }


    private void Update()
    {
        HandleInput();
    }   
    virtual public void HandleInput()
    {
        moveState.HandleInput(ref moveState, transform);
        actionState.HandleInput(this);
    }


    public ref MoveState GetReferMoveState()
    {
        return ref moveState;
    }
    public ref ActionState GetReferActionState()
    {
        return ref actionState;
    }
    public ref Animator GetReferAnimator()
    {
        return ref animator;
    }
    public ref Rigidbody GetReferRigid()
    {
        return ref rigid;
    }
}
