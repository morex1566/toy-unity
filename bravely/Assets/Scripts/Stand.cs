using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : Movement
{
    public Stand(ref CharacterRoot root_)
    {
        root = root_;
        accel = null;
        directionForMove = Vector3.zero;
        directionForAnimate = Vector3.zero;
    }

    override public void HandleInput()
    {
        // If key does not pressed
        if(!Input.anyKey)
        {
            return;
        }


        // Walk pressed
        if(Input.GetKey(KeyMap.FrontWalk))
        {
            root.Movement = walk;
        }
        if(Input.GetKey(KeyMap.BackWalk))
        {
            root.Movement = walk;
        }
        if (Input.GetKey(KeyMap.LeftWalk))
        {
            root.Movement = walk;
        }
        if (Input.GetKey(KeyMap.RightWalk))
        {
            root.Movement = walk;
        }

    }
    override public void InnerUpdate()
    {
        UpdateDirty();

        Move();
        Rotate();
        Animate();
    }
    override public void Initialize()
    {
        accel = null;
    }
    override public void UpdateDirty()
    {
        addAccel();
    }
    override public void Move()
    {
        root.Rigid.velocity = root.State.DirectionForMove.normalized * root.State.Speed;
    }
    override public void Rotate()
    {
        rotateToMousePosition();
    }
    override public void Animate()
    {
        root.Animator.SetFloat("horizontal", root.State.DirectionForAnimate.x * root.State.Speed);
        root.Animator.SetFloat("vertical", root.State.DirectionForAnimate.z * root.State.Speed);
    }

    private void addAccel()
    {
        if (root.State.Speed > 0f)
        {
            accel = decelerate;
            accel(0f, root.MovementData.DecelWalkToIdle);
        }
    }
}