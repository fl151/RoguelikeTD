using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private NavMeshAgent _agent;

    private void FixedUpdate()
    {
        var velocity = _agent.velocity.magnitude;

        if (velocity > 0.5f) _audio.volume = 1;
        else _audio.volume = 0;
    }
}
