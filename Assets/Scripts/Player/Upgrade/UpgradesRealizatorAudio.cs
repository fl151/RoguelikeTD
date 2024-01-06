using UnityEngine;

public class UpgradesRealizatorAudio : MonoBehaviour
{
    [SerializeField] private UpgradesRealizator _realizator;
    [SerializeField] private AudioClip _audio;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _realizator.SomeBuffed += OnSomeBuffed;
    }

    private void OnDisable()
    {
        _realizator.SomeBuffed -= OnSomeBuffed;
    }

    private void OnSomeBuffed()
    {
        _audioSource.PlayOneShot(_audio);
    }
}
