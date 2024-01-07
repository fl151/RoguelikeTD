using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioVolumeControler : MonoBehaviour
{
    [SerializeField] private float _volume = 1f;

    public float Volume => _volume;

    public static AudioVolumeControler Instance;

    public event UnityAction VolumeChanged;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public void SetVolume(float value)
    {
        if(_volume != value)
        {
            _volume = value;

            VolumeChanged?.Invoke();
        } 
    }
}
