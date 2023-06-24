using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationsEnemy : MonoBehaviour
{
    private const string _deathAnimCommand = "Death";
    private const string _attackAnimCommand = "Attack";

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
        _animator.SetTrigger(_attackAnimCommand);
    }

    private void StartDieAnimation()
    {
        _animator.SetTrigger(_deathAnimCommand);
    }
}
