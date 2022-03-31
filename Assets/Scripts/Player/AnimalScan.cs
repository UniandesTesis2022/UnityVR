using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimalScan : MonoBehaviour
{
    // Camera 
    [SerializeField] Transform cameraPlayer;
    [SerializeField] Camera photoCamera; 
    [SerializeField] CameraUI cameraUi;

    private RaycastHit hit;
    private float CameraRange = 500;

    private Animal currentAnimal;

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast (cameraPlayer.transform.position, cameraPlayer.transform.forward, out hit, CameraRange)){
            if(hit.transform.CompareTag("Animal")){
                var animal = hit.transform.gameObject.GetComponent<AnimalObject>().animal;
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
            cameraUi.gameObject.SetActive(false);
            ScreenshotHandler.TakePhoto(photoCamera, currentAnimal.specie.ToString(), currentAnimal.name);
            cameraUi.gameObject.SetActive(true);

            cameraUi.GetComponent<Animator>().SetBool("focus", true);
            cameraUi.GetComponent<Animator>().Play("Focused", 0 ,0.25f);
        }
    }
}
