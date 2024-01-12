using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FireSkillAudioPlayer : MonoBehaviour
{
    [SerializeField] private FireGrorund _fireGround;
    [SerializeField] private AudioClip _audio;

    [SerializeField] [Range(0, 1)] private float _volume;

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
        _audioSource.volume = _volume * AudioVolumeControler.Instance.Volume;
        
        _audioSource.PlayOneShot(_audio);
    }
}
