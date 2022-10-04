using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private Camera mainCam;
    private float trackingSpeed;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = mainCam.transform.position - this.transform.position;
        trackingSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position,
                                                 this.transform.position + offset,
                                                 trackingSpeed * Time.deltaTime);
    }
}
