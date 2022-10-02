using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private MoveState moveState;
    private Animator animator;
    private Rigidbody rigid;

    public MoveState MoveState { get { return moveState; } set { moveState = value; } }

    // Start is called before the first frame update
    void Start()
    {
        moveState = MoveState.idling;

        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Animate();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        Move();
    }

    virtual public void HandleInput()
    {
        moveState.HandleInput(ref moveState);
    }
    virtual public void Move()
    {
        moveState.Move(ref rigid);
    }
    virtual public void Animate()
    {
        moveState.Animate(ref animator);
    }
}
