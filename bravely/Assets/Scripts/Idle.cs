using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Idle : Action
{
    public Idle(ref CharacterRoot root_)
    {
        root = root_;
        eventHandler = root_.GetComponent<CharacterInteractionEvent>();

        isActive = true;
    }

    override public void InnerUpdate() { }

    override public void HandleInput()
    {
        if(!Input.anyKey)
        {
            return;
        }

        if(Input.GetKeyDown(KeyMap.Roll))
        {
            OnEventEnd();
            root.Action = Action.roll;
            root.Action.OnEventStart();
            return;
        }

        if(Input.GetKey(KeyMap.LeftWalk) && Input.GetKeyDown(KeyMap.Attack))
        {
            OnEventEnd();

            comboCount++;

            root.Action = Action.leftAttack;
            root.Action.OnEventStart();
            return;
        }

        if(Input.GetKey(KeyMap.RightWalk) && Input.GetKeyDown(KeyMap.Attack))
        {
            OnEventEnd();

            comboCount++;

            root.Action = Action.rightAttack;
            root.Action.OnEventStart();
            return;
        }

        if (Input.GetKeyDown(KeyMap.Block))
        {
            OnEventEnd();
            root.Action = Action.block;
            root.Action.OnEventStart();
            return;
        }
    }
    override public void OnEventStart()
    {
        isActive = true;
    }
    override public void OnEventEnd()
    {
        IsActive = false;
    }

    override protected void move()
    {

    }
}
