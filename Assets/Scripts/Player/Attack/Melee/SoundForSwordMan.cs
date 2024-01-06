using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundForSwordMan : MonoBehaviour
{
    [SerializeField] private AudioClip shootingSound;
    private AudioSource shootingAudio;

    private void Awake()
    {
        shootingAudio = GetComponent<AudioSource>();

        if (shootingAudio == null)
        {
            shootingAudio = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayShootingSound()
    {
        if (shootingAudio != null && shootingSound != null)
        {
            shootingAudio.PlayOneShot(shootingSound);
        }
    }
}
