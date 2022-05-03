using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadybugBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform pivot;

    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        var pivotPos = pivot.position;
        pivotPos.y = transform.position.y;
        var direction = (transform.position - pivotPos).normalized;
        transform.right = -direction;

        animator.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivot.position, transform.forward, speed * Time.deltaTime);
    }
}
