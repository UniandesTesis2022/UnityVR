using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBehaviour : MonoBehaviour
{
    private const string animatorMoving = "isMoving";

    [SerializeField] private Transform[] objectivePlaces;
    [SerializeField] private float speed;
    [SerializeField] private float offset;
    private Vector3 objectivePosition;
    private int objectiveIndex;

    [SerializeField] private float idleTime;
    private float currentTime;

    [SerializeField] private float idleSpeed;
    [SerializeField] private float movingSpeed;

    private Rigidbody _rigidbody;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        objectivePosition = objectivePlaces[0].position;
        objectiveIndex = 0;

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = (objectivePosition - transform.position).normalized * speed;
        transform.LookAt(objectivePosition, transform.up);

        currentTime = 0;
        _animator = GetComponent<Animator>();
        _animator.SetBool(animatorMoving, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator.GetBool(animatorMoving))
        {
            if( (objectivePosition - transform.position).magnitude < offset )
            {
                _animator.SetBool(animatorMoving, false);
                _animator.speed = idleSpeed;
                LockNewPosition();
            }
            else if((objectivePosition - transform.position).magnitude > 0.5f)
            {
                _animator.SetBool(animatorMoving, false);
                _animator.speed = idleSpeed;
                LockNewPosition();
            }
        }
        else
        {
            currentTime += Time.deltaTime;
            if (currentTime >= idleTime)
            {
                currentTime = 0f;
                transform.LookAt(objectivePosition, transform.up);
                _animator.SetBool(animatorMoving, true);
                _animator.speed = movingSpeed;
                _rigidbody.velocity = (objectivePosition - transform.position).normalized * speed;
            }
        }
    }

    private void LockNewPosition()
    {
        objectiveIndex = (objectiveIndex + 1) % objectivePlaces.Length;
        objectivePosition = objectivePlaces[objectiveIndex].position;
        _rigidbody.velocity = Vector3.zero;

        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
    }
}
