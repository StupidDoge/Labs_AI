using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMoveSound()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.volume = Random.Range(0.3f, 0.5f);
            _audioSource.pitch = Random.Range(0.8f, 1.1f);
            _audioSource.Play();
        }
    }
}
