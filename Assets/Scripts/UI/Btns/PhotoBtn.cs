using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhotoBtn : MonoBehaviour
{
    public Image photo;
    public Animal animal;

    private bool taken;
    [SerializeField] private TextMeshProUGUI animalName;
    
    private IngameMenuUI menu;

    public void SetUp(IngameMenuUI pMenu, Sprite pSprite, string pName, bool pTaken)
    {
        taken = pTaken;
        menu = pMenu;

        photo.sprite = pSprite;
        animalName.text = pName;
    }

    public void OnClick()
    {
        menu.ActiveDetail(animal, photo.sprite, taken);
    }
}