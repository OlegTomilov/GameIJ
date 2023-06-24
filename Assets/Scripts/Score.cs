using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private const string _keyOfScoreSave = "Score";

    [SerializeField] private Vilage _vilage;
    [SerializeField] private TMP_Text _text;

    private int _score;
    private int _maxScore;

    private void Start()
    {
        _score = 0;
        _text.text = _score.ToString();
    }

    private void OnEnable()
    {
        _vilage.TakedScore += Increase;
    }

    private void OnDisable()
    {
        _vilage.TakedScore -= Increase;
    }

    private void Increase(int scorePoint)
    {
        _score += scorePoint;
        _text.text = _score.ToString();

        if(PlayerPrefs.HasKey(_keyOfScoreSave) == false)
        {
            PlayerPrefs.SetInt(_keyOfScoreSave, _score);
        }
        else if (PlayerPrefs.HasKey(_keyOfScoreSave) && PlayerPrefs.GetInt(_keyOfScoreSave) < _score)
        {
            _maxScore = _score;
            PlayerPrefs.SetInt(_keyOfScoreSave, _maxScore);
        }
    }
}
