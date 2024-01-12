using UnityEngine;

public class LevelUpSound : MonoBehaviour
{
    [SerializeField] private PlayerExperience _playerExperience;
    [SerializeField] private AudioClip _audio;
    [SerializeField] private AudioClip _audioXp;

    [SerializeField] private AudioSource _audioSourceLevel;
    [SerializeField] private AudioSource _audioSourceXP;

    [SerializeField] [Range(0, 1)] private float _volumeUpLevel;
    [SerializeField] [Range(0, 1)] private float _volumeXP;

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
        _audioSourceLevel.volume = _volumeUpLevel * AudioVolumeControler.Instance.Volume;

        _audioSourceLevel.PlayOneShot(_audio);
    }

    private void OnXpGained()
    {
        _audioSourceXP.volume = _volumeXP * AudioVolumeControler.Instance.Volume;

        _audioSourceXP.PlayOneShot(_audioXp);
    }
}
