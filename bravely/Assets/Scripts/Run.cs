using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : Movement
{
    public Run(ref CharacterRoot root_)
    {
        root = root_;
        accel = null;
        directionForMove = Vector3.zero;
        directionForAnimate = Vector3.zero;
    }

    override public void HandleInput()
    {
        // If key does not pressed
        if (!Input.anyKey)
        {
            root.Movement = stand;
            return;
        }

        // If run does not pressed
        if(!Input.GetKey(KeyMap.Run))
        {
            root.Movement = walk;
            return;
        }

        // Walk pressed
        if (Input.GetKey(KeyMap.FrontWalk))
        {
            addDirection(root.transform.forward, Vector3.forward);
            addAccel();
        }

        if (Input.GetKey(KeyMap.BackWalk))
        {
            addDirection(-root.transform.forward, Vector3.back);
            addAccel();
        }

        if (Input.GetKey(KeyMap.LeftWalk))
        {
            addDirection(-root.transform.right, Vector3.left);
            addAccel();
        }

        if (Input.GetKey(KeyMap.RightWalk))
        {
            addDirection(root.transform.right, Vector3.right);
            addAccel();
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
        directionForMove = Vector3.zero;
        directionForAnimate = Vector3.zero;
        accel = null;
    }
    override public void UpdateDirty()
    {
        // Update direction
        root.State.DirectionForMove = directionForMove;
        root.State.DirectionForAnimate = directionForAnimate;
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
        accel = accelerate;
        accel(root.MovementData.RunSpeed, root.MovementData.AccelWalkToRun);
    }
}
