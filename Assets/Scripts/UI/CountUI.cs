using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] private MenuUI menuUI;

    public float timeRemaining = 4;

    // Start is called before the first frame update
    void Start()
    {
        countText.text = timeRemaining.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining >= 1)
        {
            timeRemaining -= Time.deltaTime;
            string actualSecond = ((int)timeRemaining).ToString();
            if(countText.text != actualSecond)
            {
                countText.text = actualSecond;
            }
        }
        else
        {
            timeRemaining = 4;
            countText.text = "4";
            menuUI.ShowIngame();
        }
    }
}
