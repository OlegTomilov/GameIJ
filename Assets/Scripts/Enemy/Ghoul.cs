using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.Died += PlayDieSound;
    }

    private void OnDisable()
    {
        _enemy.Died -= PlayDieSound;
    }

    private void PlayDieSound()
    {
        _enemy.SoundEffector.PlayGhoulDieClip();
    }

    private void PlayBornSound()
    {
        _enemy.SoundEffector.PlayGhoulBornClip();
    }
}
