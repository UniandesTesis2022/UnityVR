using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject ingameMenu;
    [SerializeField] private GameObject initialMenu;

    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        ingameMenu.SetActive(false);
        initialMenu.SetActive(true);
    }

    private void OnEnable()
    {
        transform.position = player.transform.position + offset;
    }

    public void StartGame()
    {
        ingameMenu.SetActive(true);
        initialMenu.SetActive(false);
    }
}
