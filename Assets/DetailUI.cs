using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetailUI : MonoBehaviour
{
    [SerializeField] private Image original;
    [SerializeField] private Image taken;
    [SerializeField] private Sprite placeholder;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI cientificOrderText;
    [SerializeField] private TextMeshProUGUI orderText;
    [SerializeField] private TextMeshProUGUI description;

    public void ShowDetail(Animal pAnimal, Sprite pTaken, bool pIsTaken)
    {
        taken.sprite = pIsTaken? pTaken: placeholder;
        original.sprite = pAnimal.image;

        nameText.text = pAnimal.cientificName;
        cientificOrderText.text = Animal.GetOrderCommonName(pAnimal.animalOrder);
        orderText.text = Animal.GetOrderName(pAnimal.animalOrder);
        description.text = pAnimal.description;
    }
}
