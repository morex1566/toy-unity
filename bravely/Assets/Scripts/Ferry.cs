using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferry : Action
{
    public Ferry(ref CharacterRoot root_)
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

    override public void HandleInput() { }
    override public void OnEventStart()
    {
        isActive = true;

        root.State.IsMovable = false;
        root.State.IsActionable = false;

        root.Animator.SetTrigger("Ferry");
    }
    override public void OnEventEnd()
    {
        isActive = false;

        root.State.IsMovable = true;
        root.State.IsActionable = true;
    }

    override protected void move()
    {

    }
}
