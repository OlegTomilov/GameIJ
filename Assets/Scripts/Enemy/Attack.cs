using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _delay;
    [SerializeField] private Enemy _enemy;

    private float _lastAttackTime;

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            AttackTarget(_enemy.Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void AttackTarget(Vilage target)
    {
        target.ApplayDamage(_damage);
    }
}
