using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Vilage : MonoBehaviour
{
    private const string _coinCounterAnim = "NotEnough";

    private float _maxHealthPoint = 100;
    private float _currentHealthPoint;

    [SerializeField] private int _money;
    [SerializeField] private TMP_Text _textHP;
    [SerializeField] private TMP_Text _textCountCoints;
    [SerializeField] private Coin _coin;
    [SerializeField] private Animator _animator;

    public event UnityAction<int> TakedScore;
    public event UnityAction EndedGame;

    private void Start()
    {
        _currentHealthPoint = _maxHealthPoint;
        _textHP.text = _currentHealthPoint.ToString();
        _textCountCoints.text = _money.ToString();
    }

    public void ApplayDamage(float damage)
    {
        _currentHealthPoint -= damage;
        _textHP.text = _currentHealthPoint.ToString();

        if (_currentHealthPoint <= 0)
        {
            EndedGame.Invoke();
            _currentHealthPoint = 0;
        }
    }

    public void TakeReward()
    {
        _money++;
        _textCountCoints.text = _money.ToString();
    }

    public void BuyTower(int cost)
    {
        _money -= cost;
        _textCountCoints.text = _money.ToString();
    }

    public void IncreaseScore(int scorePoint)
    {
        TakedScore.Invoke(scorePoint);
    }

    public bool IsEnoughMoney(int cost)
    {
        return _money >= cost;
    }

    public void PlayAnimation()
    {
        _animator.SetTrigger("NotEnough");
    }
}
