using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerStats))]
public class HeroMeeleAttack : MonoBehaviour
{
    private const int _enemyLayerIndex = 1 << 8;

    private float _lastAttackTime = 0f;

    private float _attackRangeCoef = 1;
    private float _criticalAttackChance = 0;
    private float _criticalAttackDamageScale = 1;

    private PlayerStats _player;
    private PlayerMovement _movement;

    public event UnityAction<bool> Attack;

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

    public void SetCriticalStats(float criticalAttackChance, float criticalAttackDamageScale)
    {
        _criticalAttackChance = criticalAttackChance;
        _criticalAttackDamageScale = criticalAttackDamageScale;
    }

    private void TryAttack()
    {
        float attackRange = _player.AttackRangeMeele * _attackRangeCoef;

        Vector3 point = transform.position + _movement.LookDirection.normalized * attackRange / 2;
        var size = new Vector3(attackRange * 1.5f, 1, attackRange);

        var hitColliders = Physics.OverlapBox(point, size / 2, Quaternion.LookRotation(_movement.LookDirection), _enemyLayerIndex);

        if (hitColliders.Length > 0)
        {
            bool isCriticalAttack = IsCriticalAttack();

            Attack?.Invoke(isCriticalAttack);

            StartCoroutine(AttackAfterDeley(0.05f, hitColliders, isCriticalAttack));
            _lastAttackTime = Time.time;
        }
    }

    private IEnumerator AttackAfterDeley(float delay, Collider[] colliders, bool isCriticalAttack)
    {
        float damage = _player.Damage;

        if (isCriticalAttack)
            damage *= _criticalAttackDamageScale;

        yield return new WaitForSeconds(delay);

        foreach (var collider in colliders)
            if (collider != null)
                collider.GetComponent<EnemyHealth>().TakeDamage(damage);   
    }

    private bool IsCriticalAttack()
    {
        if (_criticalAttackChance == 0) return false;

        return _criticalAttackChance >= Random.Range(0f, 1f);
    }
}