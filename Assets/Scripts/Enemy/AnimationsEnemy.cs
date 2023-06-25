using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationsEnemy : MonoBehaviour
{
    private const string DeathAnimCommand = "Death";
    private const string AttackAnimCommand = "Attack";

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
        _animator.SetTrigger(AttackAnimCommand);
    }

    private void StartDieAnimation()
    {
        _animator.SetTrigger(DeathAnimCommand);
    }
}
