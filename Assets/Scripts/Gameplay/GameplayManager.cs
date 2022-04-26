using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    private int total;
    private int pictures;

    public MenuUI menuUI;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        total = GameViewController.GetAllAnimals().Count;
        Debug.Log("Total " + total);
        pictures = 0;
    }

    public void AddPicture()
    {
        pictures++;
        Debug.Log("Nueva " + pictures);
        if(pictures >= total)
        {
            FinishGame();
        }
    }

    public void FinishGame()
    {
        menuUI.gameObject.SetActive(true);
        menuUI.FinishGame(pictures, total);
    }
}
