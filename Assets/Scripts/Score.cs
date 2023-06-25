using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private const string KeyOfScoreSave = "Score";

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

        if(PlayerPrefs.HasKey(KeyOfScoreSave) == false)
        {
            PlayerPrefs.SetInt(KeyOfScoreSave, _score);
        }
        else if (PlayerPrefs.HasKey(KeyOfScoreSave) 
            && PlayerPrefs.GetInt(KeyOfScoreSave) < _score)
        {
            _maxScore = _score;
            PlayerPrefs.SetInt(KeyOfScoreSave, _maxScore);
        }
    }
}
