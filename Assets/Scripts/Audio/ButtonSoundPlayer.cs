using UnityEngine;

public class ButtonSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _clip;
    [SerializeField][Range(0,1)] private float _volume;

    public static ButtonSoundPlayer Instanse;

    private void Awake()
    {
        if(Instanse == null)
        {
            Instanse = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public void Play()
    {
        _audio.volume = _volume * AudioVolumeControler.Instance.Volume;

        _audio.PlayOneShot(_clip);
    }
}
