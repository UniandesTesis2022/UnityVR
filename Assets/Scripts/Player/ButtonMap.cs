using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMap : MonoBehaviour
{
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject cameraUI;
    [SerializeField] CameraZoom cameraZoom;

    private bool activeMenu;
    private bool menuInteraction;

    private AnimalScan animalScan;

    // Start is called before the first frame update
    void Start()
    {
        animalScan = GetComponent<AnimalScan>();
        animalScan.enabled = false;
        activeMenu = false;
        menuInteraction = false;

        cameraUI.SetActive(false);
        menuUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!activeMenu)
        {
            var inputY = -1*OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !activeMenu)
            {
                Debug.Log("Index");
                animalScan.CaptureScreen();
            }
            if(inputY != 0 )
            {
                if(cameraZoom.ModifyFieldOfView(inputY)){
                    if(inputY > 0){
                        animalScan.playerSounds.ZoomIn();
                    }
                    else{
                        animalScan.playerSounds.ZoomOut();
                    }
                }
                else{
                    animalScan.playerSounds.StopZoom();
                }
            }
            else{
                animalScan.playerSounds.StopZoom();
            }
        }
        
        if (menuInteraction && OVRInput.GetDown(OVRInput.Button.Start))
        {
            Debug.Log("Start");
            activeMenu = !activeMenu;
            menuUI.SetActive(activeMenu);
            cameraUI.SetActive(!cameraUI.activeSelf);

            Time.timeScale = activeMenu ? 0 : 1;
        }
    }

    public void AllowInput()
    {
        activeMenu = false;
        menuInteraction = true;
        cameraUI.SetActive(true);
        animalScan.enabled = true;
    }

    public void DisableInput()
    {
        activeMenu = true;
        menuInteraction = false;
        cameraUI.SetActive(true);
        animalScan.enabled = false;
    }
}
