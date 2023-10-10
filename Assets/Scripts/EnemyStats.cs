using UnityEngine;
using UnityEngine.Events;

public class EnemyStats : MonoBehaviour
{
    private const float _difficultyCoefficient = 0.1f;

    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _attackCooldown = 2f;

    private EnemySpawner _spawner;

    public float MaxHealth => _maxHealth;
    public float Damage => _damage;
    public float AttackCooldown => _attackCooldown;

    public event UnityAction StatsChanged;

    public void Init(EnemySpawner spawner, int difficultyLevel)
    {
        _spawner = spawner;

        for (int i = 0; i < difficultyLevel; i++)
        {
            OnDifficultyUp();
        }

        //_spawner.DifficultyUp += OnDifficultyUp;
    }

    //private void OnDisable()
    //{
    //    _spawner.DifficultyUp -= OnDifficultyUp;
    //}

    private void OnDifficultyUp()
    {
        _maxHealth *= _difficultyCoefficient + 1;
        _damage *= _difficultyCoefficient + 1;

        _attackCooldown *= 1 - _difficultyCoefficient;

        StatsChanged?.Invoke();
    }
}
