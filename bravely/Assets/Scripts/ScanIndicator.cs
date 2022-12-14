using System.Collections;
using UnityEditor;
using UnityEngine;

public class ScanIndicator : MonoBehaviour
{
    [SerializeField] private GameObject indicator;


    void Update()
    {
        indicator.SetActive(false);

        if(Input.GetKey(KeyMap.ScoreBoard))
        {
            indicator.SetActive(true);
        }
    }
}
