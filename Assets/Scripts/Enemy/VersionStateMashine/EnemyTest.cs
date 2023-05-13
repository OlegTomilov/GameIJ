using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _reward;

    [SerializeField] private Vilage _target;
    [SerializeField] private GameObject _dropBlood;


    public Vilage Target => _target;

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }

    private void OnMouseDown()
    {
        _dropBlood.SetActive(true);
        StartCoroutine(Death());

    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _dropBlood.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(Death());
    }
}
