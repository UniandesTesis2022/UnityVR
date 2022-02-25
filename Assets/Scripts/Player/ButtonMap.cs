using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMap : MonoBehaviour
{
    [SerializeField] private AnimalScan animalScan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("Button");
            animalScan.CaptureScreen();
        }
    }
}
