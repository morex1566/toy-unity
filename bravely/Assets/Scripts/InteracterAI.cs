using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracterAI : MonoBehaviour
{
    private int triggerCount;

    // current picked object
    [SerializeField]
    public GameObject interactedObject;

    public bool Rootable;

    void Start()
    {
        triggerCount = 0;
        Rootable = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerCount++;
    }

    private void OnTriggerStay(Collider other)
    {
        // check rootable equipment
        if (interactedObject == null && other.tag == "Equipment")
        {
            Rootable = true;
            interactedObject = other.gameObject;
        }

        // check nearer rootable equipment
        if (interactedObject != other.gameObject && other.tag == "Equipment")
        {
            if (Vector3.Distance(this.transform.position, interactedObject.transform.position)
             > Vector3.Distance(this.transform.position, other.transform.position))
            {
                interactedObject = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        triggerCount--;
        interactedObject = null;
        Rootable = false;
    }
}
