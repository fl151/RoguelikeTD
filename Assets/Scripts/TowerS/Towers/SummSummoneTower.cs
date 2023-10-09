using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SummonTowerBehavoir))]
public class SummSummoneTower : Tower
{
    private const float _spawnSpeed1 = 0.125f;
    private const float _spawnSpeed2 = 0.175f;
    private const float _spawnSpeed3 = 0.225f;

    private SummonTowerBehavoir _tower;

    protected override void UpgradeLevelOne()
    {
        _tower = GetComponent<SummonTowerBehavoir>();
        _tower.SetSpawnSpeed(_spawnSpeed1);
    }

    protected override void UpgradeLevelTwo()
    {
        _tower.SetSpawnSpeed(_spawnSpeed2);
    }

    protected override void UpgradeLevelThree()
    {
        _tower.SetSpawnSpeed(_spawnSpeed3);

        base.UpgradeLevelThree();
    }
}
