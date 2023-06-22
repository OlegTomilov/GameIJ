using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private AudioSource _music;
    private bool _isSound = true;
    private int _minVolume = 0;
    private int _maxVolume = 1;

    public void ChangeSound()
    {
        if(_isSound)
        {
            _sound.volume = _minVolume;
            _music.volume = _minVolume;
            _isSound = false;
        }
        else
        {
            _sound.volume = _maxVolume;
            _music.volume = _maxVolume;
            _isSound = true;
        }
    }
}
