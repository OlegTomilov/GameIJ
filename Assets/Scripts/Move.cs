using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private GameObject _goal;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _goal.transform.position, _speed * Time.deltaTime);

        Vector3 adjustedPosition = new Vector3(_goal.transform.position.x, transform.position.y, _goal.transform.position.z);
        Quaternion targetRotation = Quaternion.LookRotation(adjustedPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speed * Time.deltaTime);
    }
}
