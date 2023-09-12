using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    [SerializeField] private GameObject _hero;
    [SerializeField] private GameObject _attackPrefab;
    [SerializeField] private float _attackRange = 5f;
    [SerializeField] private float _attackCooldawn = 1f;
    [SerializeField] private float _nextAttackTime = 0f;

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_hero.transform.position, _attackRange);

        foreach(Collider collider in hitColliders)
        {
            EnemyScript enemy = collider.GetComponent<EnemyScript>();
            if (enemy!=null&&Time.time>= _nextAttackTime)
            {
                AttackEnemy(enemy.gameObject);

                _nextAttackTime = Time.time + _attackCooldawn;
            }
        }
    }

    void AttackEnemy(GameObject enemy)
    {
        
        GameObject attack = Instantiate(_attackPrefab, _hero.transform.position, Quaternion.identity);
        attack.GetComponent<AttackScript>().SetTarget(enemy);
    }
}
