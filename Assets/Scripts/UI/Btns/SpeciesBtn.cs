using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeciesBtn : MonoBehaviour
{
    [SerializeField] private Text text;

    private IngameMenuUI menu;

    private Animal.Order specie;

    public void SetUp(IngameMenuUI pMenu, Animal.Order pSpecie){
        specie = pSpecie;
        menu = pMenu;

        text.text = Animal.GetOrderCommonName(pSpecie);
    }

    public void OnClick(){
        menu.RenderPhotos(specie);
    }
}