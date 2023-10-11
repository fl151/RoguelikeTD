using System;
using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private Transform _attackTransform; 

    private HeroMeeleAttack _player;
    private PlayerMovement _playerMovement;

    private Vector3 _position;
    private Transform _parent;
    private Quaternion _rotation;

    private void Awake()
    {
        _player = GetComponentInParent<HeroMeeleAttack>();
        _playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void Start()
    {
        _position = transform.localPosition;
        _parent = transform.parent;
        _rotation = transform.localRotation;
    }

    private void OnEnable()
    {
        _player.Attack += OnAttack;
    }  

    private void OnDisable()
    {
        _player.Attack -= OnAttack;
    }

    private void OnAttack()
    {
        transform.parent = _attackTransform;
        transform.position = _attackTransform.position + Vector3.up * 0.5f + _playerMovement.LookDirection.normalized * 0.5f;
        transform.localRotation = Quaternion.Euler(-90, 135,90);

        StartCoroutine(BackAfterDelay());
    }

    private IEnumerator BackAfterDelay()
    {
        var time = Time.time;
        float rotationSpeed = 1000;

        transform.RotateAround(transform.parent.position + Vector3.up * 0.5f, Vector3.up, 90);

        while (Time.time - time < 180 / rotationSpeed)
        {
            yield return new WaitForEndOfFrame();

            transform.RotateAround(_attackTransform.position + Vector3.up * 0.5f, Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        transform.parent = _parent;
        transform.localPosition = _position;
        transform.localRotation = _rotation;
    }
}