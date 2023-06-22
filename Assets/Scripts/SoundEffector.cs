using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _coinClip;
    [SerializeField] private AudioClip _lightClip;
    [SerializeField] private AudioClip _zombieBornClip;
    [SerializeField] private AudioClip _zombieDieClip;
    [SerializeField] private AudioClip _ghoulBornClip;
    [SerializeField] private AudioClip _ghoulDieClip;

    public void PlayCoinClip()
    {
        _audioSource.PlayOneShot(_coinClip);
    }

    public void PlayLightClip()
    {
        _audioSource.PlayOneShot(_lightClip);
    }

    public void PlayZombieBornClip()
    {
        _audioSource.PlayOneShot(_zombieBornClip);
    }

    public void PlayZombieDieClip()
    {
        _audioSource.PlayOneShot(_zombieDieClip);
    }

    public void PlayGhoulBornClip()
    {
        _audioSource.PlayOneShot(_ghoulBornClip);
    }

    public void PlayGhoulDieClip()
    {
        _audioSource.PlayOneShot(_ghoulDieClip);
    }
}
