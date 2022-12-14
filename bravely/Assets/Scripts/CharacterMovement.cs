using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeReference] private CharacterRoot root;

    public void Start()
    {
        root = GetComponent<CharacterRoot>();
    }

    public void FixedUpdate()
    {
        if(root.State.IsAlive)
        {
            if (root.State.IsMovable) { UpdateMovement(); }
            if (root.State.IsActionable) { UpdateAction(); }
        }
    }

    public void Update()
    {
        // Initialize
        if(root.State.IsAlive)
        {
            if (root.State.IsMovable) { InitializeMovement(); }
        }

        // Handle input
        if(root.State.IsAlive)
        {
            if (root.State.IsMovable) { HandleInputMovement(); }
            if (root.State.IsActionable) { HandleInputAction(); }
        }

    }

    virtual public void InitializeMovement()
    {
        root.Movement.Initialize();
    }
    virtual public void HandleInputMovement()
    {
        root.Movement.HandleInput();
    }
    virtual public void UpdateMovement()
    {
        root.Movement.InnerUpdate();
    }
    virtual public void UpdateAction()
    {
        root.Action.InnerUpdate();
    }
    virtual public void HandleInputAction()
    {
        root.Action.HandleInput();
    }
}
