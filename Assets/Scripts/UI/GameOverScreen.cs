using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _screen;
    [SerializeField] private Vilage _vilage;

    private int _mainScreenIndex = 0;
    private int _gameScreenIndex = 1;

    private void EndGame()
    {
        _screen.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _vilage.EndedGame += EndGame;
    }

    private void OnDisable()
    {
        _vilage.EndedGame -= EndGame;
    }

    public void Play()
    {
        SceneManager.LoadScene(_gameScreenIndex);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene(_mainScreenIndex);
    }
}
