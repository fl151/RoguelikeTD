using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMan : MonoBehaviour
{
    [SerializeField] private GameObject _hero;
    [SerializeField] private float _attackRange = 5f;
    [SerializeField] private float _attackCooldown = 2f;

    private Animator _animator;

    private float _lastAttackTime = 0f;

    private void Start()
    {
        _animator = _hero.GetComponent<Animator>();
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_hero.transform.position, _attackRange);

        GameObject nearestEnemy = FindNearestEnemy(hitColliders);

        if (nearestEnemy != null)
        {
            if (Time.time - _lastAttackTime >= _attackCooldown)
            {
                AttackEnemy(nearestEnemy);
                _lastAttackTime = Time.time;
            }
        }
        else
        {
            _animator.ResetTrigger("isAttack");
        }
    }

    GameObject FindNearestEnemy(Collider[] colliders)
    {
        GameObject nearestEnemy = null;
        float nearestDistance = float.MaxValue;

        foreach (Collider collider in colliders)
        {
            EnemyHealth enemy = collider.GetComponent<EnemyHealth>();

            if (enemy != null && collider.gameObject.activeSelf)
            {
                float distance = Vector3.Distance(_hero.transform.position, collider.transform.position);

                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = collider.gameObject;

                }
            }
        }

        return nearestEnemy;
    }


    void AttackEnemy(GameObject enemy)
    {
        _animator.SetTrigger("isAttack");
    }
}