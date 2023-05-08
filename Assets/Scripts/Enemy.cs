using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _dropBlood;

    public event UnityAction StartAttack;
    public event UnityAction Died;
    public event UnityAction<float> StoppedMove;

    private void OnMouseDown()
    {
        _dropBlood.SetActive(true);
        Died.Invoke();
        StoppedMove.Invoke(0);
        StartCoroutine(Death());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Frame"))
        {
            StartAttack.Invoke();
            StoppedMove.Invoke(0);
        }
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    private void OnEnable ()
    {
        _dropBlood.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(Death());
    }
}
