using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _takeEffect;

    public void OnMouseDown()
    {
        _takeEffect.SetActive(true);
        StartCoroutine(delayDestroy());
    }

    private void OnEnable()
    {
        StopCoroutine(delayDestroy());
    }

    private IEnumerator delayDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
