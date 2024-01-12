using UnityEngine;

public class WinMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip victoryMusic;
    [SerializeField] [Range(0, 1)] private float _volume;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {            
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        PlayVictoryMusic();
    }

    public void PlayVictoryMusic()
    {        
        if (audioSource != null && victoryMusic != null)
        {
            audioSource.volume = _volume * AudioVolumeControler.Instance.Volume;
            audioSource.clip = victoryMusic;
            audioSource.Play();

            Debug.Log(audioSource.volume);
        }
    }
}
