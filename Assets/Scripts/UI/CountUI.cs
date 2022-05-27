using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] private MenuUI menuUI;

    public float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        countText.text = timeRemaining.ToString();
    }

    private void OnEnable()
    {
        Time.timeScale = 0.05f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining >= 1)
        {
            timeRemaining -= Time.deltaTime / 0.05f;
            string actualSecond = ((int)timeRemaining).ToString();
            if(countText.text != actualSecond)
            {
                countText.text = actualSecond;
            }
        }
        else
        {
            timeRemaining = 3;
            countText.text = "3";
            menuUI.ShowIngame();
        }
    }
}
