 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimalScan : MonoBehaviour
{
    // Camera 
    [SerializeField] Camera cameraPhoto; 
    [SerializeField] CameraUI cameraUI;

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
                    cameraUI.StartFocus();
                }
            }
            else{
                cameraUI.StopFocus();
                currentAnimal = null;
            }
        }
        else{
            cameraUI.StopFocus();
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
                if(GameplayManager.instance != null)
                {
                    GameplayManager.instance.AddPicture();
                }
            }
            Texture2D photo = ScreenshotHandler.TakePhoto(cameraPhoto, currentAnimal.specie.ToString(), currentAnimal.name);
            cameraUI.ShowPhoto(photo, currentAnimal.image);
        }
    }
}
