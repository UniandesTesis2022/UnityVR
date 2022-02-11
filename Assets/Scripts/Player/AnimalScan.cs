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
    [SerializeField] Canvas uiPlayer;

    private RaycastHit hit;
    private float CameraRange = 500;

    // Debug
    [SerializeField] Text textName;

    [SerializeField]
    InputActionReference triggerAction;

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
                    textName.text = animal.name;
                    Debug.Log("Animal " + textName.text);
                }
            }
            else{
                textName.text = "";
            }
        }
        else{
            textName.text = "";
        }
    }

    private void CaptureScreen(InputAction.CallbackContext obj)
    {
        StartCoroutine(CaptureScreen());
    }

    public IEnumerator CaptureScreen()
    {
        // Wait till the last possible moment before screen rendering to hide the UI
        yield return null;
        uiPlayer.enabled = false;
    
        // Wait for screen rendering to complete
        yield return new WaitForEndOfFrame();
    
        // Take screenshot
        ScreenCapture.CaptureScreenshot("screenshot.png");
    
        // Show UI after we're done
        uiPlayer.enabled = true;
    }
}
