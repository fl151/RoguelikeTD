using UnityEngine;

public class SoundForSwordMan : MonoBehaviour
{
    [SerializeField] private AudioClip shootingSound;
    [SerializeField] private AudioSource shootingAudio;
    [SerializeField] [Range(0, 1)] private float _volume;

    public void PlayShootingSound()
    {
        if (shootingAudio != null && shootingSound != null)
        {
            shootingAudio.volume = _volume * AudioVolumeControler.Instance.Volume;

            shootingAudio.PlayOneShot(shootingSound);
        }
    }
}
