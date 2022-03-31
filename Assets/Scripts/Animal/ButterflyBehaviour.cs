using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyBehaviour : MonoBehaviour
{

    [SerializeField] private Transform pivot;
    [SerializeField] private bool right;
    private float speed;
    private float speedY;
    private Vector3 moveDirection;

    [SerializeField] private float range;
    private float minHeight;
    private float maxHeight;
    private Vector3 heightDirection;

    // Start is called before the first frame update
    void Start()
    {
        var pivotPos = pivot.position;
        pivotPos.y = transform.position.y;
        var direction = (transform.position - pivotPos).normalized;
        transform.right = -direction;

        minHeight = (transform.position.y - range);
        maxHeight = (transform.position.y + range);

        heightDirection = transform.up;

        speed = Random.Range(40,60);
        speedY = Random.Range(0.8f, 1.5f);

        if(right)
        {
            moveDirection = Vector3.up;
        }
        else
        {
            moveDirection = -Vector3.up;
            Vector3 rot = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(new Vector3(rot.x, rot.y + 180, rot.z));
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivot.position, moveDirection, speed * Time.deltaTime);

        transform.position += heightDirection * speedY * Time.deltaTime;
        if(transform.position.y > maxHeight)
        {
            heightDirection = -transform.up;
        }
        else if(transform.position.y < minHeight)
        {
            heightDirection = transform.up;
        }

    }
}
