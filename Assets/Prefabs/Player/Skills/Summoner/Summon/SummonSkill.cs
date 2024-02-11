using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SummonSkill : Skill
{
    private const int _bonusCountHelpers1 = 1;
    private const float _reduseCooldawn2 = 3;
    private const int _bonusCountHelpers3 = 1;

    [SerializeField] private Helper _helperPrafab;

    private bool _isColldawnFinished = true;

    private float _cooldawn = 15f;
    private int _countHelpersPerSpawn = 1;

    private List<Helper> _helpers = new List<Helper>();

    private float _currentHelpersDamage;
    private float _currentHelpersAttackSpeed;
    private float _currentHelpersHealth;

    private ObjectPool<Helper> _helpersPool;

    public static SummonSkill Instance;
    public event UnityAction Spawned;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _helpersPool = new ObjectPool<Helper>(_helperPrafab, 10, true);

        var stats = _helperPrafab.GetComponent<HelperStats>();

        _currentHelpersDamage = stats.Damage;
        _currentHelpersHealth = stats.MaxHealth;
        _currentHelpersAttackSpeed = stats.AttackSpeed;
    }

    private void Update()
    {
        if (_isColldawnFinished)
        {
            _isColldawnFinished = false;

            StartCoroutine(SpawnHelpers());
        }
    }

    public void SpawnHelper(Vector3 position)
    {
        var helper = _helpersPool.GetFreeElement();
        helper.transform.position = position;

        var helperStats = helper.GetComponent<HelperStats>();

        helperStats.SetStats(_currentHelpersDamage, _currentHelpersAttackSpeed, _currentHelpersHealth);
        helperStats.OffEffect();

        if (_helpers.Contains(helper) == false)
            _helpers.Add(helper);

        Spawned?.Invoke();
    }

    public void AddStats(float damage, float attackSpeed, float health)
    {
        _currentHelpersDamage += damage;
        _currentHelpersAttackSpeed += attackSpeed;
        _currentHelpersHealth += health;

        UpdateHelpersStats();
    }

    protected override void UpgradeLevelOne()
    {
        _countHelpersPerSpawn += _bonusCountHelpers1;
    }

    protected override void UpgradeLevelTwo()
    {
        _cooldawn -= _reduseCooldawn2;
    }

    protected override void UpgradeLevelThree()
    {
        _countHelpersPerSpawn += _bonusCountHelpers3;

        base.UpgradeLevelThree();
    }

    private IEnumerator SpawnHelpers()
    {
        yield return new WaitForSeconds(_cooldawn * 0.2f);

        for (int i = 0; i < _countHelpersPerSpawn; i++)
        {
            SpawnHelper(transform.position);
        }

        yield return new WaitForSeconds(_cooldawn * 0.8f);

        _isColldawnFinished = true;
    }

    private void UpdateHelpersStats()
    {
        foreach (var helper in _helpers)
        {
            if (helper.gameObject.activeSelf == false)
            {
                _helpers.Remove(helper);
            }
            else
            {
                helper.GetComponent<HelperStats>().SetStats(_currentHelpersDamage, _currentHelpersAttackSpeed);
            }
        }
    }
}
