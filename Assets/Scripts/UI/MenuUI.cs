using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject initialMenu;
    [SerializeField] private GameObject countdownUI;
    [SerializeField] private GameObject ingameMenu;
    [SerializeField] private GameObject finalMenu;

    [SerializeField] private ButtonMap buttonMap;

    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {        
        if (GameViewController.instance.isPlaying)
        {
            countdownUI.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            initialMenu.SetActive(true);
        }
    }

    private void OnEnable()
    {
        transform.position = player.transform.position + offset;
    }

    public void StartGame(float pSeconds)
    {
        GameViewController.SetTime(pSeconds);
        initialMenu.SetActive(false);
    }

    public void ShowIngame()
    {
        buttonMap.AllowInput();

        countdownUI.SetActive(false);
        ingameMenu.SetActive(true);
        gameObject.SetActive(false);

        FindObjectOfType<GameplayManager>().gameObject.SetActive(true);
    }

    public void FinishGame(int pPictures, int pTotal)
    {
        buttonMap.DisableInput();
        
        finalMenu.SetActive(true);
        finalMenu.GetComponent<FinalMenuUI>().SetUp(pPictures, pTotal);
    }
}
