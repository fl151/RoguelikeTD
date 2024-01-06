using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip victoryMusic;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayVictoryMusic()
    {
        if (audioSource != null && victoryMusic != null)
        {
            audioSource.clip = victoryMusic;
            audioSource.Play();
        }
    }
}
