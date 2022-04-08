using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraUI : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Image original;
    [SerializeField] private Image taken;

    private void Start() {
        animator = GetComponent<Animator>();    
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
    }
}
