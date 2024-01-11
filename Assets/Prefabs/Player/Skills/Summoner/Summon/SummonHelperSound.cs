using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonHelperSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private SummonSkill _summonSkill;
    

    private void OnEnable()
    {
        _summonSkill.Spawned += OnSceletonSpawned;
    }

    private void OnDisable()
    {
        _summonSkill.Spawned -= OnSceletonSpawned;
    }

    private void OnSceletonSpawned()
    {
        _audio.Play();
    }
}
