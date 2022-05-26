using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraUI : MonoBehaviour
{
    private Animator animator;

    // Description
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI cientificOrderText;
    [SerializeField] private TextMeshProUGUI orderText;
    [SerializeField] private TextMeshProUGUI description;

    // Photos
    [SerializeField] private Image original;
    [SerializeField] private Image taken;
    [SerializeField] private float totalSeconds;
    private float imageSeconds;
    private float infoSeconds;

    private void Start() {
        animator = GetComponent<Animator>();
        if(animator == null)
        {
            Debug.Log("Animator null!");
        }
        taken.gameObject.SetActive(false);
        original.gameObject.SetActive(false);

        nameText.gameObject.SetActive(false);
        cientificOrderText.gameObject.SetActive(false);
        orderText.gameObject.SetActive(false);
        description.gameObject.SetActive(false);

        imageSeconds = 0;
    }

    private void Update()
    {
        if(imageSeconds > 0)
        {
            imageSeconds -= Time.deltaTime;
        }
        else if(taken.gameObject.activeInHierarchy)
        {
            imageSeconds = 0;

            taken.gameObject.SetActive(false);
            original.gameObject.SetActive(false);
        }

        if (infoSeconds > 0)
        {
            infoSeconds -= Time.deltaTime;
        }
        else if (nameText.gameObject.activeInHierarchy)
        {
            infoSeconds = 0;

            nameText.gameObject.SetActive(false);
            cientificOrderText.gameObject.SetActive(false);
            orderText.gameObject.SetActive(false);
            description.gameObject.SetActive(false);
        }
    }

    public void StartFocus(Animal pAnimal, bool pExists)
    {
        animator.SetBool("oldFocus", pExists);
        animator.SetBool("focus", true);

        nameText.text = pAnimal.cientificName;
        cientificOrderText.text = Animal.GetOrderCommonName(pAnimal.animalOrder);
        orderText.text = Animal.GetOrderName(pAnimal.animalOrder);
        description.text = pAnimal.description;

        nameText.gameObject.SetActive(true);
        cientificOrderText.gameObject.SetActive(true);
        orderText.gameObject.SetActive(true);
        description.gameObject.SetActive(true);

        infoSeconds = 10;
    }

    public void StopFocus(){
        if (animator != null)
        {
            animator.SetBool("focus", false);
        }
    }

    private void OnDisable()
    {
        StopFocus();
    }

    public void ShowPhoto(Texture2D pTaken, Sprite pOriginal)
    {
        taken.sprite = Sprite.Create(pTaken, new Rect(0, 0, pTaken.width, pTaken.height), new Vector2(pTaken.width / 2, pTaken.height / 2));
        original.sprite = pOriginal;

        taken.gameObject.SetActive(true);
        original.gameObject.SetActive(true);
        imageSeconds = totalSeconds;
    }
}
