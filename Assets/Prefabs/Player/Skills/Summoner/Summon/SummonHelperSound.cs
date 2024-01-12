using UnityEngine;

public class SummonHelperSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private SummonSkill _summonSkill;

    [SerializeField] [Range(0, 1)] private float _volume;


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
        _audio.volume = _volume * AudioVolumeControler.Instance.Volume;

        _audio.Play();
    }
}
