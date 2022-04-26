using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraUI : MonoBehaviour
{
    private Animator animator;

    // Description
    [SerializeField] private TextMeshProUGUI commonName;
    [SerializeField] private TextMeshProUGUI cientificName;
    [SerializeField] private TextMeshProUGUI description;

    // Photos
    [SerializeField] private Image original;
    [SerializeField] private Image taken;
    [SerializeField] private float totalSeconds;
    private float seconds;

    private void Start() {
        animator = GetComponent<Animator>();
        if(animator == null)
        {
            Debug.Log("Animator null!");
        }
        taken.gameObject.SetActive(false);
        original.gameObject.SetActive(false);

        seconds = 0;
    }

    private void Update()
    {
        if(seconds > 0)
        {
            seconds -= Time.deltaTime;
        }
        else if(taken.gameObject.activeInHierarchy)
        {
            seconds = 0;

            taken.gameObject.SetActive(false);
            original.gameObject.SetActive(false);
        }
    }

    public void StartFocus(Animal pAnimal, bool pExists){
        animator.SetBool("focus", true);

        commonName.text = pAnimal.commonName;
        cientificName.text = pAnimal.cientificName;
        description.text = pAnimal.description;

        commonName.gameObject.SetActive(true);
        cientificName.gameObject.SetActive(true);
        description.gameObject.SetActive(true);
    }

    public void StopFocus(){
        if (animator != null)
        {
            animator.SetBool("focus", false);
        }
        commonName.gameObject.SetActive(false);
        cientificName.gameObject.SetActive(false);
        description.gameObject.SetActive(false);
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
        seconds = totalSeconds;
    }
}
