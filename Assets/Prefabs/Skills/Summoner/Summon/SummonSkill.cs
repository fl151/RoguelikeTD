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

    public void SpawnHelper(Vector3 position)
    {
        var helper = Instantiate(_helperPrafab, transform);
        helper.transform.parent = null;
        helper.transform.position = position;

        _helpers.Add(helper);
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

    private void Update()
    {
        if (_isColldawnFinished)
        {
            _isColldawnFinished = false;

            StartCoroutine(SpawnHelpers());
        }
    }

    private IEnumerator SpawnHelpers()
    {
        yield return new WaitForSeconds(_cooldawn);

        for (int i = 0; i < _countHelpersPerSpawn; i++)
        {
            SpawnHelper(transform.position);
        }
        
        _isColldawnFinished = true;
    }
}
