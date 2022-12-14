using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeReference] private CharacterRoot root;
    [SerializeField] private Interacter interacter;

    public void Start()
    {
        root = GetComponent<CharacterRoot>();
        interacter = GetComponentInChildren<Interacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (root.State.IsAlive &&
            root.State.IsActionable
            ) 
        { 
            HandleInput();
        }
    }


    virtual public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.F) && root.Equipment == null)
        {
            if (interacter.Rootable)
            {
                grapEquipment(interacter.interactedObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.G) && root.Equipment != null)
        {
            dropEquipment();
        }

        if(Input.GetKeyDown(KeyMap.Roll))
        {
            root.Animator.SetTrigger("Roll");
        }
    }

    private void grapEquipment(GameObject equipment_)
    {
        root.Equipment = equipment_.GetComponent<Equipment>();


        equipment_.transform.parent = GameObject.FindWithTag("Hand").transform;

        root.Equipment.Equiped(root);
    }

    private void dropEquipment()
    {
        root.Equipment.transform.position += this.transform.forward / 2;
        root.Equipment.transform.parent = null;

        root.Equipment.Dropped(root);
        root.Equipment = null;
    }
}
