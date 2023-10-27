using UnityEngine;

public class ExperienceDroper
{
    private float _chanceDrop;
    private ObjectPool<Experience> _expPool;

    public ExperienceDroper(EnemySpawner spawner, Experience prefab, float chanceDrop, Transform conteiner)
    {
        spawner.EnemySpawned += OnEnemySpawned;
        _chanceDrop = Mathf.Clamp01(chanceDrop);

        _expPool = new ObjectPool<Experience>(prefab, 10, conteiner, true);
    }

    private void OnEnemySpawned(EnemyHealth enemy)
    {
        enemy.Dead += OnEnemyDied;
    }

    private void OnEnemyDied(EnemyHealth enemy)
    {
        if (_chanceDrop != 0)
            if (Random.Range(0f, 1f) <= _chanceDrop)
            {
                var exp = _expPool.GetFreeElement();
                exp.transform.position = enemy.transform.position;
            }

        enemy.Dead -= OnEnemyDied;
    }
}
