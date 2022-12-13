using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundController : MonoBehaviour
{
    [SerializeField] private AudioClip _deathSound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayDeathSound()
    {
        _audioSource.PlayOneShot(_deathSound);
    }
}
