using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoBtn : MonoBehaviour
{
    [SerializeField] private Image photo;

    [SerializeField] private Text animalName;

    public void SetUp(Sprite pSprite, string pName){
        photo.sprite = pSprite;
        animalName.text = pName;
    }

    public void SetUp(string pName){
        animalName.text = pName;
    }

}