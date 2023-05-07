using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction StartAttack;
    public event UnityAction<float> StoppedMove;

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Frame"))
        {
            StartAttack.Invoke();
            StoppedMove.Invoke(0);
        }
    }
}
