using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ModelAnimations : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _player;
    private HeroMeeleAttack _meeleAttack;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponentInParent<PlayerMovement>();

        _meeleAttack = _player.GetComponent<HeroMeeleAttack>();
    }

    private void OnEnable()
    {
        _meeleAttack.Attack += OnPlayerAttack;
        _meeleAttack.Attack += OnPlayerNotAttack;
    }

    private void OnDisable()
    {
        _meeleAttack.Attack -= OnPlayerAttack;
        _meeleAttack.Attack -= OnPlayerNotAttack;
    }

    private void Update()
    {
        _animator.SetBool(Animator.StringToHash("isRun"), _player.IsRuning);
    }

    private void OnPlayerAttack()
    {
        _animator.SetTrigger("isAttack");
    }

    private void OnPlayerNotAttack()
    {
        _animator.ResetTrigger("isAttack");
    }
}
