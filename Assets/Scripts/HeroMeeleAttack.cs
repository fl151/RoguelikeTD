using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerStats))]
public class HeroMeeleAttack : MonoBehaviour
{
    private float _lastAttackTime = 0f;

    private PlayerStats _player;

    public event UnityAction Attack;
    public event UnityAction NotAttack;

    private void Awake()
    {
        _player = GetComponent<PlayerStats>();
    }
    
    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _player.AttackRange);

        if (hitColliders.Length > 0)
        {
            if (Time.time - _lastAttackTime >= 1 / _player.AttackSpeed)
            {
                Attack?.Invoke();
                _lastAttackTime = Time.time;
            }
        }
        else
        {
            NotAttack?.Invoke();
        }
    }
}