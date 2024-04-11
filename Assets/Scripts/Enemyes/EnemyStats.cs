using UnityEngine;
using UnityEngine.Events;

public class EnemyStats : MonoBehaviour
{
    private const float _difficultyCoefficient = 7f;

    private const float _health = 100f;
    private const float _damageC = 10f;
    private const float _attackCooldownC = 2f;

    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _attackCooldown = 2f;

    private EnemySpawner _spawner;

    public float MaxHealth => _maxHealth;
    public float Damage => _damage;
    public float AttackCooldown => _attackCooldown;

    public event UnityAction StatsChanged;
    public event UnityAction Inited;

    public void Init(EnemySpawner spawner)
    {
        _spawner = spawner;

        SetDifficulty();

        Inited?.Invoke();

        //_spawner.DifficultyUp += OnDifficultyUp;


        // Если нужно чтобы усилялись все враги при
        //повышении сложности то раскоментировать подписку и отписку
    }

    //private void OnDisable()
    //{
    //    _spawner.DifficultyUp -= OnDifficultyUp;
    //}

    private void SetDifficulty()
    {
        ResetStats();

        float difficultiUp = GetDifficulty();

        _maxHealth *= difficultiUp + 1;
        _damage *= difficultiUp + 1;

        _attackCooldown *= 1 - difficultiUp;

        StatsChanged?.Invoke();
    }

    private float GetDifficulty()
    {
        float curveValue = 1 - Mathf.Cos((float)_spawner.CurrentEnemyCount / _spawner.MaxEnemyCount * 3.14f);
        return curveValue * _difficultyCoefficient;
    }

    private void ResetStats()
    {
        _maxHealth = _health;
        _damage = _damageC;
        _attackCooldown = _attackCooldownC;
    }
}
