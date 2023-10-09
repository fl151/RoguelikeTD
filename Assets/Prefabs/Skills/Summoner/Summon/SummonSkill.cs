using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSkill : Skill
{
    private const int _bonusCountHelpers1 = 1;
    private const float _reduseCooldawn2 = 2;
    private const int _bonusCountHelpers3 = 1;

    [SerializeField] private GameObject _helperPrafab;

    private bool _isColldawnFinished = true;

    private float _cooldawn = 7f;
    private int _countHelpersPerSpawn = 1;

    private List<GameObject> _helpers = new List<GameObject>();

    private float _currentHelpersDamage;
    private float _currentHelpersAttackSpeed;
    private float _currentHelpersHealth;

    public static SummonSkill Instance;

    public void SpawnHelper(Vector3 position)
    {
        var helper = Instantiate(_helperPrafab, transform);
        helper.transform.parent = null;
        helper.transform.position = position;

        helper.GetComponent<HelperStats>().SetStats(_currentHelpersDamage, _currentHelpersAttackSpeed, _currentHelpersHealth);

        _helpers.Add(helper);
    }

    public void AddStats(float damage, float attackSpeed, float health)
    {
        _currentHelpersDamage += damage;
        _currentHelpersAttackSpeed += attackSpeed;
        _currentHelpersHealth += health;

        UpdateHelpersStats();
    }

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
            if(helper == null)
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
