using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeciesBtn : MonoBehaviour
{
    [SerializeField] private Text text;

    private MenuUI menu;

    private string specie;

    public void SetUp(MenuUI pMenu, string pName){
        specie = pName;
        menu = pMenu;

        text.text = pName;
    }

    public void OnClick(){
        menu.RenderPhotos(specie);
    }
}