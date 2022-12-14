using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterInteractionEvent : MonoBehaviour
{
    [SerializeReference] private CharacterRoot root;

    // prior action
    private Action dirty;

    // combo flag
    private bool isCombo;

    public bool IsCombo { get { return isCombo; } set { isCombo = value; } }

    public void Start()
    {
        root = GetComponent<CharacterRoot>();
        dirty = null;
        isCombo = false;
    }

    public void OnRoll(int state)
    {        
        if(state == 1)
        {
            root.Action.IsActive = true;

            root.Rigid.AddForce(transform.forward * 75f);

            root.State.IsMovable = false;
            root.State.IsActionable = false;
        }
        
        if(state == 0)
        {
            root.Action.IsActive = false;

            root.State.IsMovable = true;
            root.State.IsActionable = true;
        }
    }
    public void OnAttack(int state)
    {
        if (state == 1)
        {
            root.Action.IsActive = true;

            root.Rigid.AddForce(transform.forward * 25f);

            root.State.IsMovable = false;
            root.State.IsActionable = false;
        }

        if (state == 0)
        {
            root.Action.IsActive = false;

            root.State.IsMovable = true;
            root.State.IsActionable = true;
        }
    }
    public void OnSubRoutine(int state)
    {
        if(state == 1)
        {
            root.State.IsActionable = true;
            dirty = root.Action;
        }

        if(state == 0)
        {
            if(dirty == root.Action)
            {
                root.State.IsActionable = false;
            }
        }
    }
    public void OnCombo(int state)
    {
        if(state == 1)
        {
            isCombo = true;
        }

        if(state == 0)
        {
            isCombo = false;
        }
    }
    public void OnLeftParticle(int state)
    {
        if(state == 1)
        {
            root.Equipment.leftSlashParticle.Play();
        }

        if(state == 0)
        {
            root.Equipment.leftSlashParticle.Stop();
        }
    }
    public void OnRightParticle(int state)
    {
        if (state == 1)
        {
            root.Equipment.rightSlashParticle.Play();
        }

        if (state == 0)
        {
            root.Equipment.leftSlashParticle.Stop();
        }
    }
}
