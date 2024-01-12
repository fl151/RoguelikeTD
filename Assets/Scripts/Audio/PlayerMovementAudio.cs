using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] [Range(0, 1)] private float _volume;

    private void Update()
    {
        var velocity = _agent.velocity.magnitude;

        _audio.volume = 0;
        if(Time.timeScale == 1)
        {            
            if (velocity > 0.5f) _audio.volume = _volume * AudioVolumeControler.Instance.Volume;            
        }       
    }
}
