using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button _stopButton;
    [SerializeField] private GameObject _screen;

    public void StopPlay()
    {
        Time.timeScale = 0;
        _screen.SetActive(true);
    }

    public void Resume()
    {
        _screen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 0;
    }
}
