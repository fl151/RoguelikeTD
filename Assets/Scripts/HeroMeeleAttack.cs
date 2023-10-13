using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerStats))]
public class HeroMeeleAttack : MonoBehaviour
{
    private const int _enemyLayerIndex = 1 << 8;

    private float _lastAttackTime = 0f;

    private float _attackRangeCoef = 1;

    private PlayerStats _player;
    private PlayerMovement _movement;

    public event UnityAction Attack;
    public event UnityAction NotAttack;

    public float AttackRangeCoefficient => _attackRangeCoef;

    private void Awake()
    {
        _player = GetComponent<PlayerStats>();
        _movement = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        if (Time.time - _lastAttackTime >= 1 / _player.AttackSpeed * 1.75f)
        {
            TryAttack();
        }
    }

    public void SetAttackRangeCoefficient(float attackRangeCoefficient)
    {
        _attackRangeCoef = attackRangeCoefficient;
    }

    private void TryAttack()
    {
        float attackRange = _player.AttackRangeMeele * _attackRangeCoef;

        Vector3 point = transform.position + _movement.LookDirection.normalized * attackRange / 2;
        var size = new Vector3(attackRange * 1.5f, 1, attackRange);

        var hitColliders = Physics.OverlapBox(point, size / 2, Quaternion.LookRotation(_movement.LookDirection), _enemyLayerIndex);

        if (hitColliders.Length > 0)
        {
            Attack?.Invoke();

            StartCoroutine(AttackAfterDeley(0.05f, hitColliders));
            _lastAttackTime = Time.time;
        }
    }

    private IEnumerator AttackAfterDeley(float delay, Collider[] colliders)
    {
        yield return new WaitForSeconds(delay);

        foreach (var collider in colliders)
        {
            if (collider != null)
                collider.GetComponent<EnemyHealth>().TakeDamage(_player.Damage);
        }
    }
}