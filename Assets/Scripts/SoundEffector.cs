using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _coinClip;
    [SerializeField] private AudioClip _lightClip;

    public void PlayCoinClip()
    {
        _audioSource.PlayOneShot(_coinClip);
    }

    public void PlayLightClip()
    {
        _audioSource.PlayOneShot(_lightClip);
    }
}
