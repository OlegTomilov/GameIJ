using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationsEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _enemy.StartAttack += StartAttackAnimation;
        _enemy.Died += StartDieAnimation;
    }

    private void OnDisable()
    {
        _enemy.StartAttack -= StartAttackAnimation;
        _enemy.Died -= StartDieAnimation;
    }

    private void StartAttackAnimation()
    {
        _animator.SetTrigger("Attack");
    }

    private void StartDieAnimation()
    {
        _animator.SetTrigger("Death");
    }
}
