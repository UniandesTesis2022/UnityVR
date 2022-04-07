using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalMenuUI : MonoBehaviour
{
    [SerializeField] GameObject background;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        background.SetActive(false);
    }

    internal void SetUp(int pPictures, int pTotal)
    {
        scoreText.text = pPictures + "/" + pTotal;
        resultText.text = pPictures >= pTotal ? "You won": "You lose";
    }
}
