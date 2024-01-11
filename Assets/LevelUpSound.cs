using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSound : MonoBehaviour
{
    [SerializeField] private PlayerExperience _playerExperience;
    [SerializeField] private AudioClip _audio;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _playerExperience.LevelUp += OnLevelUp;
    }

    private void OnDisable()
    {
        _playerExperience.LevelUp -= OnLevelUp;
    }

    private void OnLevelUp()
    {
        _audioSource.PlayOneShot(_audio);
    }
}
