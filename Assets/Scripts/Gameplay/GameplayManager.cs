using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    [SerializeField] private TextMeshProUGUI timeTxt;

    private float seconds;
    private int intSeconds;

    private bool finished;
    private int total;
    private int pictures;

    public MenuUI menuUI;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            instance = this;
        }

        finished = false;
        seconds = GameViewController.instance.duration;
        intSeconds = (int)seconds;
        TranslateSeconds();

        total = GameViewController.GetAllAnimals().Count;

    }

    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            if (seconds > 0)
            {
                seconds -= Time.deltaTime;
                var tempSeconds = (int)seconds;
                if (tempSeconds < intSeconds)
                {
                    intSeconds = tempSeconds;
                    TranslateSeconds();
                }
            }
            else
            {
                FinishGame();
            }
        }
    }

    public void TranslateSeconds()
    {
        int minutes = intSeconds / 60;
        int newSeconds = intSeconds % 60;

        timeTxt.text = (minutes >= 10 ? "" : "0") + minutes + ":" + (newSeconds >= 10? "":"0") + newSeconds;
    }

    public void AddPicture()
    {
        pictures++;
    }

    public void FinishGame()
    {
        finished = true;
        menuUI.gameObject.SetActive(true);
        menuUI.FinishGame(pictures, total);
    }
}
