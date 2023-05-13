using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private GameObject _goal;
    [SerializeField] private Rigidbody _rigidBody;

    private float _speed = 40;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _goal.transform.position, _speed * Time.deltaTime);
        Vector3 adjustedPosition = new Vector3(_goal.transform.position.x, transform.position.y, _goal.transform.position.z);

        if (_speed > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(adjustedPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        _speed = 40;
        _rigidBody.freezeRotation = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Frame"))
        {
            _rigidBody.freezeRotation = true;
        }
    }
}
