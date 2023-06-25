using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHeatlh : MonoBehaviour
{
    [SerializeField] private Card _card;
    [SerializeField] private Tower _tower;
    [SerializeField] private GameObject _indicator;

    private int _healthPoint;
    private int _midleHealth;
    private int _minHealth;
    private int _halfStep = 2;
    private int _quaterStep = 4;

    private void Start()
    {
        _healthPoint = _card.HealthPoint;
        _midleHealth = _healthPoint / _halfStep;
        _minHealth = _healthPoint / _quaterStep;
    }

    private void OnEnable()
    {
        _tower.Destroyed += OnDecreasedHealth;
    }

    private void OnDisable()
    {
        _tower.Destroyed -= OnDecreasedHealth;
    }

    private void OnDecreasedHealth()
    {
        _healthPoint--;
        ChangeIndication();

        if(_healthPoint <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void ChangeIndication()
    {
        if(_healthPoint <= _midleHealth && _healthPoint > _minHealth)
        {
            _indicator.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if(_healthPoint <= _minHealth)
        {
            _indicator.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            _indicator.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
