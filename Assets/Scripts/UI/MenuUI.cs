using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private InitialMenuUI initialMenu;
    [SerializeField] private CountUI countdownUI;
    [SerializeField] private IngameMenuUI ingameMenu;

    [SerializeField] private ButtonMap buttonMap;

    // Start is called before the first frame update
    void Start()
    {
        if (GameplayManager.instance.isPlaying)
        {
            countdownUI.gameObject.SetActive(true);
        }
        else
        {
            initialMenu.gameObject.SetActive(true);
        }
    }

    public void StartGame(float pSeconds)
    {
        initialMenu.gameObject.SetActive(false);
        SceneManager.LoadScene("MainScenario");
    }

    public void ShowIngame()
    {
        buttonMap.AllowInput();

        countdownUI.gameObject.SetActive(false);
        ingameMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("InitialMenu");
    }

    public void FinishGame(int pPictures, int pTotal)
    {
        buttonMap.DisableInput();
        
        ingameMenu.GetComponent<IngameMenuUI>().Finish(pPictures, pTotal);
    }
}
