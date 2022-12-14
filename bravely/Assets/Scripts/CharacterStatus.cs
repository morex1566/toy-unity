using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject slider;


    private CharacterRoot root;
    private Transform sliderTransform;

    void Start()
    {
        root = GetComponent<CharacterRoot>();

        sliderTransform = transform.Find("slider_pivot");
        if(!sliderTransform)
        {
            Debug.Log("slider transform null");
        }

        slider = Instantiate(prefab);
        slider.transform.parent = canvas.transform;
    }

    void Update()
    {
        if(slider)
        {
            var screenPos = Camera.main.WorldToScreenPoint(sliderTransform.position);

            slider.transform.position = screenPos;
        }
    }
}
