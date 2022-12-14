using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 offset;

    public void Start()
    {

        offset = cam.transform.position - this.transform.position;
        speed = 3f;
    }

    public void Update()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position,
                                              this.transform.position + offset,
                                              speed * Time.deltaTime);
    }
}
