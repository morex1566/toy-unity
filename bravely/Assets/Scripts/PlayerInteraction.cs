using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject  weapon;
    private MoveState   moveState;
    private ActionState actionState;
    [SerializeField]
    private Collider   interactionRange;

    void Update()
    {
        HandleInput();
    }
    private void HandleInput()
    {
        
    }
}
