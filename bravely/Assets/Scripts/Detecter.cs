using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecter : MonoBehaviour
{
    private int triggerCount;

    // current picked object
    [SerializeField]
    private GameObject detectedObject;

    public GameObject DetectedObject { get { return detectedObject; } set { detectedObject = value; } }

    void Start()
    {
        triggerCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy") { triggerCount++; }
    }

    private void OnTriggerStay(Collider other)
    {
        // check detected object
        if( detectedObject == null && other.tag == "Enemy")
        {
            detectedObject = other.gameObject;
        }

        // check nearer object 
        if(detectedObject != other.gameObject && other.tag == "Enemy")
        {
            if(Vector3.Distance(this.transform.position, detectedObject.transform.position)
             > Vector3.Distance(this.transform.position, other.transform.position))
            {
                detectedObject = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy") { triggerCount--; }
        if (triggerCount == 0) { unDetected(); }
    }

    private void unDetected()
    {
        detectedObject = null;
    }
}
