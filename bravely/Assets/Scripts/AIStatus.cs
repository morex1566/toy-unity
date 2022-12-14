using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStatus : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject prefab;
    [SerializeField] public GameObject slider;


    private RootAI root;
    private Transform sliderTransform;

    public GameObject Slider{ get; set;}

    ~AIStatus()
    {
        Destroy(slider);
    }

    void Start()
    {
        root = GetComponent<RootAI>();

        sliderTransform = transform.Find("slider_pivot"); 
        if (!sliderTransform)
        {
            Debug.Log("slider transform null");
        }

        slider = Instantiate(prefab);
        slider.transform.parent = canvas.transform;
    }

    void Update()
    {
        if (slider)
        {
            var screenPos = Camera.main.WorldToScreenPoint(sliderTransform.position);

            slider.transform.position = screenPos;
        }
    }
}