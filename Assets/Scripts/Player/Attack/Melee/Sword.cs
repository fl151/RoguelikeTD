using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private Transform _attackTransform;
    [SerializeField] private ParticleSystem _criticalEffect;

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

    private void OnAttack(bool isCritical)
    {
        transform.parent = _attackTransform;
        transform.position = _attackTransform.position + Vector3.up * 0.5f + _playerMovement.LookDirection.normalized * 0.5f;
        transform.localRotation = Quaternion.Euler(-90, 135, 90);
        transform.localScale *= _player.AttackRangeCoefficient;

        if (isCritical)
        {
            ParticleSystem effect = Instantiate(_criticalEffect, null);

            effect.transform.position = transform.position;
            effect.transform.rotation = Quaternion.LookRotation(_playerMovement.LookDirection);
            effect.transform.localScale = transform.localScale * 0.4f;

            Destroy(effect.gameObject, 0.5f);
        }

        StartCoroutine(BackAfterDelay());
    }

    private IEnumerator BackAfterDelay()
    {
        var time = Time.time;
        float rotationSpeedAround = 1000;

        transform.RotateAround(transform.parent.position + Vector3.up * 0.5f, Vector3.up, 90);

        while (Time.time - time < 180 / rotationSpeedAround)
        {
            yield return new WaitForEndOfFrame();

            transform.RotateAround(_attackTransform.position + Vector3.up * 0.5f, Vector3.up, -rotationSpeedAround * Time.deltaTime);
        }

        transform.parent = _parent;
        transform.localPosition = _position;
        transform.localRotation = _rotation;
        transform.localScale = new Vector3(1, 1, 1);
    }
}