using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMap : MonoBehaviour
{
    [SerializeField] GameObject menuUI;

    private bool activeMenu;

    private AnimalScan animalScan;

    // Start is called before the first frame update
    void Start()
    {
        animalScan = GetComponent<AnimalScan>();

        activeMenu = false;
        menuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !activeMenu)
        {
            Debug.Log("Index");
            animalScan.CaptureScreen();
        }
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            Debug.Log("Start");
            activeMenu = !activeMenu;
            menuUI.SetActive(activeMenu);

            Time.timeScale = activeMenu ? 0 : 1;
        }
    }
}
