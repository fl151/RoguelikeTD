using UnityEngine;

public class ExperienceDroper
{
    private float _chanceDrop;
    private float _chanceDropBig;
    private ObjectPool<Experience> _expPool;
    private ObjectPool<Experience> _bigExpPool;

    public ExperienceDroper(EnemySpawner spawner, Experience prefab1, Experience prefab2,  float chanceDrop, float chanceDropBig, Transform conteiner)
    {
        spawner.EnemySpawned += OnEnemySpawned;
        _chanceDrop = Mathf.Clamp01(chanceDrop);
        _chanceDropBig = Mathf.Clamp01(chanceDropBig);

        _expPool = new ObjectPool<Experience>(prefab1, 10, conteiner, true);
        _bigExpPool = new ObjectPool<Experience>(prefab2, 10, conteiner, true);
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
                SpawnExp(_expPool.GetFreeElement(), enemy.transform.position);
            }
            else
            {
                if(Random.Range(0f, 1f) <= _chanceDropBig)
                {
                    SpawnExp(_bigExpPool.GetFreeElement(), enemy.transform.position);
                }
            }

        enemy.Dead -= OnEnemyDied;
    }

    private void SpawnExp(Experience exp, Vector3 position)
    {
        exp.transform.position = position;
    }
}
