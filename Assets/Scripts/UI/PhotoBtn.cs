using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoBtn : MonoBehaviour
{
    private Image photo;

    public void SetUp(Sprite pSprite){
        photo = GetComponent<Image>();
        photo.sprite = pSprite;
    }

}