using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState
{
    // Base state
    public bool IsAlive;


    // Movement state
    public bool IsMovable;
    public bool IsRotatable;
    public Vector3 DirectionForMove;
    public Vector3 DirectionForAnimate;
    public float Speed;


    // Action state
    public bool IsActionable;


    // Interactable state
    public bool IsInteractable;

    public CharacterState()
    {
        // Base state
        IsAlive = true;


        // Movement state
        IsMovable = true;
        IsRotatable = true;
        DirectionForMove = Vector3.zero;
        DirectionForAnimate = Vector3.zero;
        Speed = 0f;


        // Action state
        IsActionable = true;


        // Interactable state
        IsInteractable = true;
    }
}
