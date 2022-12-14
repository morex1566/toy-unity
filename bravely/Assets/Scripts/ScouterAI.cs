using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScouterAI : MonoBehaviour
{
    private int triggerCount;

    // current picked object
    [SerializeField]
    private GameObject scoutedObject;

    public GameObject ScoutedObject { get { return scoutedObject; } set { scoutedObject = value; } }

    void Start()
    {
        triggerCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { triggerCount++; }
    }

    private void OnTriggerStay(Collider other)
    {
        // check detected object
        if (scoutedObject == null && other.tag == "Player")
        {
            scoutedObject = other.gameObject;
        }

        // check nearer object 
        if (scoutedObject != other.gameObject && other.tag == "Player")
        {
            if (Vector3.Distance(this.transform.position, scoutedObject.transform.position)
             > Vector3.Distance(this.transform.position, other.transform.position))
            {
                scoutedObject = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") { triggerCount--; }
        if (triggerCount == 0) { unDetected(); }
    }

    private void unDetected()
    {
        scoutedObject = null;
    }
}
