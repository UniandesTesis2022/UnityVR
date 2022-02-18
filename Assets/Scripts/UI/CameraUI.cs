using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUI : MonoBehaviour
{
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();    
    }

    public void StartFocus(){
        animator.SetBool("focus", true); 
    }

    public void StopFocus(){
        animator.SetBool("focus", false);
    }
}
