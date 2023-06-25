using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardHolderManager : MonoBehaviour
{
    [SerializeField] private Transform _cardHolderPosition;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vilage _vilage;
    [SerializeField] private Card[] _cards;

    [SerializeField] private List<GameObject> _plantedCards;

    private void Start()
    {
        for (int i = 0; i < _cards.Length; i++)
        {
            CreateCard(i);
        }
    }

    private void CreateCard(int number)
    {
        GameObject card = Instantiate(_prefab, _cardHolderPosition);

        CardManager cardManager = card.GetComponent<CardManager>();
        cardManager.TransferObjects(_cards[number], _vilage);
        
        _plantedCards.Add(card);

        _plantedCards[number].GetComponentInChildren<Image>().sprite = _cards[number].Logo;
        _plantedCards[number].GetComponentInChildren<TMP_Text>().text = _cards[number].Cost.ToString();
    }
}
