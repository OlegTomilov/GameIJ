using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Vilage : MonoBehaviour
{
    private float _maxHealthPoint = 100;
    private float _currentHealthPoint;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _currentHealthPoint = _maxHealthPoint;
        _text.text = _currentHealthPoint.ToString();
    }

    public void ApplayDamage(float damage)
    {
        _currentHealthPoint -= damage;
    }
}
