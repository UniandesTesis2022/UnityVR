 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimalScan : MonoBehaviour
{
    // Camera 
    [SerializeField] Camera cameraPhoto; 
    [SerializeField] CameraUI cameraUi;

    public PlayerSounds playerSounds;

    private RaycastHit hit;
    private float CameraRange = 500;

    private Animal currentAnimal;    
    

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast (cameraPhoto.transform.position, cameraPhoto.transform.forward, out hit, CameraRange)){
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
            playerSounds.Shoot();

            if (!ScreenshotHandler.PhotoExists(currentAnimal.specie.ToString(), currentAnimal.name))
            {
                GameplayManager.AddPicture();
            }
            ScreenshotHandler.TakePhoto(cameraPhoto, currentAnimal.specie.ToString(), currentAnimal.name);
        }
    }
}
