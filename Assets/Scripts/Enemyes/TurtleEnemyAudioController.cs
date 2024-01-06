using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TurtleEnemyAudioController : MonoBehaviour
{
    [SerializeField] private AudioClip damageSound; 
    private AudioSource audioSource; 

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDamageSound()
    {        
        if (audioSource != null && damageSound != null)
        {
            audioSource.PlayOneShot(damageSound);
        }
    }
}
