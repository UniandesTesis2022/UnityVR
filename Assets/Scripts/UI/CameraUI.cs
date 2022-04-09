using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraUI : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Image original;
    [SerializeField] private Image taken;
    [SerializeField] private float totalSeconds;
    private float seconds;

    private void Start() {
        animator = GetComponent<Animator>();
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

    public void StartFocus(){
        animator.SetBool("focus", true); 
    }

    public void StopFocus(){
        animator.SetBool("focus", false);
    }

    private void OnDisable()
    {
        animator.SetBool("focus", false);
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
