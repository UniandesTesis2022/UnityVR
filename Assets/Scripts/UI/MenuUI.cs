using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject ingameMenu;
    [SerializeField] private GameObject initialValue;

    // Start is called before the first frame update
    void Start()
    {
        ingameMenu.SetActive(false);
        initialValue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
