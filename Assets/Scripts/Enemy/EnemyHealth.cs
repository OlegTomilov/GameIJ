using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealtPoint;
    [SerializeField] private int _currentHealthPoint;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private List<GameObject> _visualHP;

    public event UnityAction Died;
    public event UnityAction<Vector3> SpawnedCoin;


    private void OnEnable()
    {
        for (int i = 0; i < _maxHealtPoint; i++)
        {
            _visualHP[i].SetActive(true);
        }

        _currentHealthPoint = _maxHealtPoint;
        _enemy.DecreasedHP += DecreaseHealth;
    }

    private void OnDisable()
    {
        _enemy.DecreasedHP -= DecreaseHealth;
    }

    private void DecreaseHealth()
    {
        _currentHealthPoint--;

        if(_currentHealthPoint >= 0)
            _visualHP[_currentHealthPoint].SetActive(false);

        if(_currentHealthPoint <= 0)
        {
            Died.Invoke();
            SpawnedCoin.Invoke(_enemy.transform.position);
        }
    }

    public void TakeDamage(int damage)
    {
        if(damage >= 0)
        {
            for (int i = 0; i < damage; i++)
            {
                DecreaseHealth();
            }
        }
    }
}
