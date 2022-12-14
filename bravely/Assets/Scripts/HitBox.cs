using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private GameObject self;
    
    private AIStatus status;

    // Start is called before the first frame update
    void Start()
    {
        status = GetComponentInParent<AIStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Equipment")
        {
            Destroy(status.slider);
            Destroy(self);
        }
    }
}
