using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        var pivotPos = pivot.position;
        pivotPos.y = transform.position.y;
        var direction = (transform.position - pivotPos ).normalized;
        transform.right = -direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivot.position, Vector3.up, speed * Time.deltaTime);
    }
}
