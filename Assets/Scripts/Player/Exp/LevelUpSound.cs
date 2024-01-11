using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSound : MonoBehaviour
{
    [SerializeField] private PlayerExperience _playerExperience;
    [SerializeField] private AudioClip _audio;
    [SerializeField] private AudioClip _audioXp;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _playerExperience.LevelUp += OnLevelUp;
        _playerExperience.ExpGained += OnXpGained;
    }

    private void OnDisable()
    {
        _playerExperience.LevelUp -= OnLevelUp;
        _playerExperience.ExpGained -= OnXpGained;
    }

    private void OnLevelUp()
    {
        _audioSource.PlayOneShot(_audio);
    }

    private void OnXpGained()
    {
        _audioSource.PlayOneShot(_audioXp);
    }
}
