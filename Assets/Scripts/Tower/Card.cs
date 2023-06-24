using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cards", menuName = "Cards/New cards", order = 52)]
public class Card : ScriptableObject
{
    [SerializeField] private int _cost;
    [SerializeField] private int _damage;
    [SerializeField] private int _healthPoint;
    [SerializeField] private Sprite _logo;
    [SerializeField] private GameObject _prefab;

    public int Cost => _cost;
    public int Damage => _damage;
    public int HealthPoint => _healthPoint;
    public Sprite Logo => _logo;
    public GameObject GetPrefab() { return _prefab; }
}
