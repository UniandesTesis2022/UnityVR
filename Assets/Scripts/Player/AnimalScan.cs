using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class AnimalScan : MonoBehaviour
{
    // Camera 
    [SerializeField] Transform cameraPlayer;
    [SerializeField] CameraUI cameraUi;

    private RaycastHit hit;
    private float CameraRange = 500;

    private Animal currentAnimal;

    // Debug
    [SerializeField] InputActionReference triggerAction;

     private void OnEnable()
    {
        triggerAction.action.performed += CaptureScreen;
    }
    private void OnDisable()
    {
        triggerAction.action.performed -= CaptureScreen;

    }

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

    private void CaptureScreen(InputAction.CallbackContext obj)
    {
        if(currentAnimal != null){
            String path = "Photos/" + currentAnimal.specie.ToString();
            ScreenshotHandler.TakeScreenshot(path, currentAnimal.name + "1");
        }
    }
}
