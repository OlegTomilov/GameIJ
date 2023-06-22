using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private EnemyHealth _enemyHealth;

    private int _minRandom = 0;
    private int _maxRandom = 10;
    private int _positionY = 5;

    private void OnEnable()
    {
        _enemyHealth.SpawnedCoin += Spawn;
    }

    private void OnDisable()
    {
        _enemyHealth.SpawnedCoin -= Spawn;
    }

    private void Spawn(Vector3 deathPoint)
    {
        int randomNumber = Random.Range(_minRandom, _maxRandom);
        Vector3 spawnPoint = new Vector3(deathPoint.x, _positionY, deathPoint.z);

        if (randomNumber < 3)
        {
            Instantiate(_coin, spawnPoint, Quaternion.identity);
        }
    }
}
