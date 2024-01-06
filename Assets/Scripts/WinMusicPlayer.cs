using UnityEngine;

public class WinMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip victoryMusic;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {            
            audioSource = gameObject.AddComponent<AudioSource>();
        }        
    }

    public void PlayVictoryMusic()
    {        
        if (audioSource != null && victoryMusic != null)
        {
            audioSource.clip = victoryMusic;
            audioSource.Play();
        }
    }
}
