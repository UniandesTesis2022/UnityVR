using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimalScan : MonoBehaviour
{
    // Camera 
    [SerializeField] Transform cameraPlayer;
    [SerializeField] CameraUI cameraUi;

    private RaycastHit hit;
    private float CameraRange = 500;

    private Animal currentAnimal;

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast (cameraPlayer.transform.position, cameraPlayer.transform.forward, out hit, CameraRange)){
            if(hit.transform.CompareTag("Animal")){
                Animal animal = hit.transform.gameObject.GetComponent<AnimalObject>().animal;
                if(animal != null){
                    currentAnimal = animal;
                    cameraUi.StartFocus();
                }
            }
            else{
                cameraUi.StopFocus();
                currentAnimal = null;
            }
        }
        else{
            cameraUi.StopFocus();
            currentAnimal = null;
        }
    }

    public void CaptureScreen()
    {
        Debug.Log("Capture");
        if (currentAnimal != null){
            String path = "Photos/" + currentAnimal.specie.ToString();
            ScreenshotHandler.TakeScreenshot(path, currentAnimal.name + "1");
        }
    }
}
