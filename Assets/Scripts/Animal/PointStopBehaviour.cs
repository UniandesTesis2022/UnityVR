using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointStopBehaviour : MonoBehaviour
{
    private const string animatorMoving = "isMoving";
    private const string animatorFlying = "isFlying";

    [SerializeField] private Transform[] objectivePlaces;
    [SerializeField] private int objectiveStop;
    [SerializeField] private float stopTime;
    private bool stopped;

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
        stopped = false;

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
            if( (objectivePosition - transform.position).magnitude < offset && !stopped)
            {
                if(objectiveIndex == objectiveStop)
                {
                    StartCoroutine(StopFewSeconds());
                }
                else
                {
                    _animator.SetBool(animatorMoving, false);
                    _animator.speed = idleSpeed;
                    LockNewPosition();
                }
            }
            else if ((objectivePosition - transform.position).magnitude > 0.5f)
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

    private IEnumerator StopFewSeconds()
    {
        stopped = true;
        _animator.SetBool(animatorFlying, false);
        _rigidbody.velocity = Vector3.zero;
        yield return new WaitForSeconds(stopTime);

        _animator.SetBool(animatorMoving, false);
        _animator.SetBool(animatorFlying, true);
        _animator.speed = idleSpeed;
        LockNewPosition();
        stopped = false;
    }

    private void LockNewPosition()
    {
        objectiveIndex = (objectiveIndex + 1) % objectivePlaces.Length;
        objectivePosition = objectivePlaces[objectiveIndex].position;
        _rigidbody.velocity = Vector3.zero;
    }
}
