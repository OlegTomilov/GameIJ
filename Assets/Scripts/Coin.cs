using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _takeEffect;

    private float _delayOfDestroy;

    public void OnMouseDown()
    {
        _takeEffect.gameObject.SetActive(true);
        StartCoroutine(DelayDestroy());
    }

    private void OnEnable()
    {
        StopCoroutine(DelayDestroy());
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(_delayOfDestroy);
        Destroy(gameObject);
    }

}
