using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _delay;
    //[SerializeField] private Vilage _vilage;
    private float _lastAttackTime;

    public Vilage Vilage {get; set;}


    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            AttackTarget(Vilage);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void AttackTarget(Vilage target)
    {
        target.ApplayDamage(_damage);
    }
}
