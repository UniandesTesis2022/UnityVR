using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMap : MonoBehaviour
{
    [SerializeField] GameObject menuUI;

    private AnimalScan animalScan;

    // Start is called before the first frame update
    void Start()
    {
        animalScan = GetComponent<AnimalScan>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("Index");
            animalScan.CaptureScreen();
        }
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            Debug.Log("Start");
            menuUI.SetActive(!menuUI.activeSelf);
        }
    }
}
