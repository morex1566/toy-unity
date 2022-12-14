using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class LeftAttack : Action
{
    private Equipment equipment;

    public LeftAttack(ref CharacterRoot root_)
    {
        root = root_;
        eventHandler = root_.GetComponent<CharacterInteractionEvent>();

        equipment = root_.Equipment;

        isActive = false;
    }

    override public void InnerUpdate()
    {
        if(isActive)
        {
            
        }
        else
        if (!isActive)
        {
            OnEventEnd();

            comboCount = 0;

            root.Action = Action.idle;
            root.Action.OnEventStart();
        }
    }

    override public void HandleInput() 
    {
        if (Input.GetKeyDown(KeyMap.Block))
        {
            OnEventEnd();

            comboCount = 0;

            root.Action = Action.block;
            root.Action.OnEventStart();

            return;
        }

        if(Input.GetKeyDown(KeyMap.Roll))
        {
            OnEventEnd();

            comboCount = 0;

            root.Action = Action.roll;
            root.Action.OnEventStart();

            return;
        }

        if (eventHandler.IsCombo)
        {

            if (Input.GetKeyDown(KeyMap.Attack) && Input.GetKey(KeyMap.FrontWalk))
            {
                OnEventEnd();

                comboCount = 0;

                root.Action = Action.heavyLeftAttack;
                root.Action.OnEventStart();

                return;
            }

            if (Input.GetKeyDown(KeyMap.Attack) && Input.GetKey(KeyMap.BackWalk))
            {
                OnEventEnd();

                comboCount = 0;

                root.Action = Action.HeavyRightAttack;
                root.Action.OnEventStart();

                return;
            }

            if (Input.GetKeyDown(KeyMap.Attack))
            {
                OnEventEnd();

                comboCount++;

                root.Action = Action.rightAttack;
                root.Action.OnEventStart();

                return;
            }
        }
    }
    override public void OnEventStart()
    {
        isActive = true;

        eventHandler.IsCombo = false;
        root.State.IsMovable = false;
        root.State.IsActionable = false;

        root.Animator.SetTrigger("LightAttack2");
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
