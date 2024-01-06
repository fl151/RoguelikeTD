using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] private float _count;
    [SerializeField] private AudioClip _pickupSound;

    public float Count => _count;

    private void OnTriggerEnter(Collider other)
    {        
        HeroMeeleAttack heroMeeleAttack = other.GetComponent<HeroMeeleAttack>();

        if (heroMeeleAttack != null)
        {            
            PlayPickupSound(heroMeeleAttack.gameObject);                 
        }
    }

    private void PlayPickupSound(GameObject player)
    {       
        AudioSource playerAudio = player.GetComponent<AudioSource>();
        
        if (playerAudio == null)
        {
            playerAudio = player.AddComponent<AudioSource>();
        }
       
        if (_pickupSound != null)
        {
            playerAudio.PlayOneShot(_pickupSound);
        }
    }
}