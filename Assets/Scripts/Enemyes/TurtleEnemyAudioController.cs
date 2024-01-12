using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TurtleEnemyAudioController : MonoBehaviour
{
    [SerializeField] private AudioClip damageSound; 
    private AudioSource audioSource;
    [SerializeField] [Range(0, 1)] private float _volume;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDamageSound()
    {        
        if (audioSource != null && damageSound != null)
        {
            audioSource.volume = _volume * AudioVolumeControler.Instance.Volume;

            audioSource.PlayOneShot(damageSound);
        }
    }
}
