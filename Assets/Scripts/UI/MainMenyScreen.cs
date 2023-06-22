using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenyScreen : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _screen;
    [SerializeField] private TMP_Text _textMaxScore;

    private void Start()
    {
        Time.timeScale = 0;
        SetMaxScore();
    }
    private void SetMaxScore()
    {
        _textMaxScore.text = PlayerPrefs.GetInt("Score").ToString();
        PlayerPrefs.Save();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenScene(int indexOfScene)
    {
        SceneManager.LoadScene(indexOfScene);
        Time.timeScale = 1;
    }

    public void DelKey()
    {
        PlayerPrefs.DeleteKey("Score");
    }
}
