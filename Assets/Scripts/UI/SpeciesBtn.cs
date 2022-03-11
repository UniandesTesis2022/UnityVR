using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeciesBtn : MonoBehaviour
{
    [SerializeField] private Text text;

    private MenuUI menu;

    private Animal.species specie;

    public void SetUp(MenuUI pMenu, Animal.species pSpecie){
        specie = pSpecie;
        menu = pMenu;

        text.text = pSpecie.ToString();
    }

    public void OnClick(){
        menu.RenderPhotos(specie);
    }
}