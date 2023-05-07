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
    }

    private void OnDisable()
    {
        _enemy.StartAttack += StartAttackAnimation;
    }

    private void StartAttackAnimation()
    {
        _animator.SetTrigger("Attack");
    }
}
