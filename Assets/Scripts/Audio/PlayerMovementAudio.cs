using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] [Range(0, 1)] private float _volume;

    private bool _isGamePaused = false;

    private void OnEnable()
    {
        PauseManager.Instance.Unpaused += OnGameUnpaused;
        PauseManager.Instance.Paused += OnGamePaused;

        _audio.volume = _volume * AudioVolumeControler.Instance.Volume;
    }

    private void OnDisable()
    {
        PauseManager.Instance.Unpaused -= OnGameUnpaused;
        PauseManager.Instance.Paused -= OnGamePaused;
    }

    private void Update()
    {
        var velocity = _agent.velocity.magnitude;

        if(_isGamePaused == false && velocity > 0.5f)
        {
            _audio.enabled = true;
        }
        else
        {
            _audio.enabled = false;
        }
    }

    private void OnGameUnpaused()
    {
        _isGamePaused = false;
    }

    private void OnGamePaused()
    {
        _isGamePaused = true;
    }
}
