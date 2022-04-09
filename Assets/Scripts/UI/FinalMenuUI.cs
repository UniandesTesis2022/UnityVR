using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalMenuUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] TextMeshProUGUI scoreText;

    internal void SetUp(int pPictures, int pTotal)
    {
        scoreText.text = pPictures + "/" + pTotal;
        resultText.text = pPictures >= pTotal ? "You won": "You lose";
    }
}
