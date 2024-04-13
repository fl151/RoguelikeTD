using UnityEngine;

[RequireComponent(typeof(FireTowerBehavoir))]
public class MageFireTower : Tower
{
    private const float _damage1 = 250;
    private const float _damage2 = 335;
    private const float _damage3 = 400;

    private const float _attackSpeed1 = 0.4f;
    private const float _attackSpeed2 = 0.5f;
    private const float _attackSpeed3 = 0.7f;

    private const float _attackRange1 = 5;
    private const float _attackRange2 = 7;
    private const float _attackRange3 = 10;

    private FireTowerBehavoir _tower;

    protected override void UpgradeLevelOne()
    {
        _tower = GetComponent<FireTowerBehavoir>();

        _tower.SetStats(_damage1, _attackSpeed1, _attackRange1);
    }

    protected override void UpgradeLevelTwo()
    {
        _tower.SetStats(_damage2, _attackSpeed2, _attackRange2);
    }

    protected override void UpgradeLevelThree()
    {
        _tower.SetStats(_damage3, _attackSpeed3, _attackRange3);

        base.UpgradeLevelThree();
    }
}
