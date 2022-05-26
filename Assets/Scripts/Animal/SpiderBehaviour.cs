using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBehaviour : MonoBehaviour
{
    private const string animatorMoving = "isMoving";

    [SerializeField] private Transform[] objectivePlaces;
    [SerializeField] private float speed;
    [SerializeField] private float offset;
    private Vector3 objectivePosition;
    private int objectiveIndex;

    [SerializeField] private float idleTime;
    private float currentTime;

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
            if( (objectivePosition - transform.position).magnitude < offset)
            {
                _animator.SetBool(animatorMoving, false);
                _animator.speed = 0.25f;
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
                _animator.speed = speed;
                _rigidbody.velocity = (objectivePosition - transform.position).normalized * speed;
            }
        }
    }

    private void LockNewPosition()
    {
        objectiveIndex = (objectiveIndex + 1) % objectivePlaces.Length;
        objectivePosition = objectivePlaces[objectiveIndex].position;
        _rigidbody.velocity = Vector3.zero;
    }
}
