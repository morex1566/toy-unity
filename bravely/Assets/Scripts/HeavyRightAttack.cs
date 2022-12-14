using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyRightAttack : Action
{
    private Equipment equipment;

    public HeavyRightAttack(ref CharacterRoot root_)
    {
        root = root_;
        eventHandler = root_.GetComponent<CharacterInteractionEvent>();

        equipment = root_.Equipment;

        isActive = false;
    }

    override public void InnerUpdate()
    {
        if (isActive)
        {

        }
        else
        if (!isActive)
        {
            OnEventEnd();
            root.Action = Action.idle;
            root.Action.OnEventStart();
        }
    }

    override public void HandleInput()
    {
        if (Input.GetKeyDown(KeyMap.Block))
        {
            OnEventEnd();
            root.Action = Action.block;
            root.Action.OnEventStart();

            return;
        }

        if (Input.GetKeyDown(KeyMap.Roll))
        {
            OnEventEnd();
            root.Action = Action.roll;
            root.Action.OnEventStart();

            return;
        }
    }
    override public void OnEventStart()
    {
        isActive = true;

        eventHandler.IsCombo = false;
        root.State.IsMovable = false;
        root.State.IsActionable = false;

        root.Animator.SetTrigger("HeavyAttack1");
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
