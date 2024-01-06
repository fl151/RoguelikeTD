using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FireSkillAudioPlayer : MonoBehaviour
{
    [SerializeField] private FireGrorund _fireGround;
    [SerializeField] private AudioClip _audio;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _fireGround.Hited += OnHited;
    }

    private void OnDisable()
    {
        _fireGround.Hited -= OnHited;
    }

    private void OnHited()
    {
        _audioSource.PlayOneShot(_audio);
    }
}
