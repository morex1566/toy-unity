using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Action
{
    public Block(ref CharacterRoot root_)
    {
        root = root_;
        eventHandler = root_.GetComponent<CharacterInteractionEvent>();

        isActive = false;
    }

    override public void InnerUpdate() 
    {
        if (!isActive)
        {
            OnEventEnd();
            root.Action = Action.idle;
            root.Action.OnEventStart();
        }
    }

    override public void HandleInput()
    {
        if (!Input.GetKey(KeyMap.Block))
        {
            OnEventEnd();
            root.Action = Action.idle;
            root.Action.OnEventStart();
        }
    }

    override public void OnEventStart()
    {
        isActive = true;
        root.State.IsActionable = true;
        root.State.IsMovable = true;

        root.Animator.SetBool("Block", true);
    }
    override public void OnEventEnd()
    {
        isActive = false;

        root.Animator.SetBool("Block", false);
    }

    override protected void move()
    {

    }
}
