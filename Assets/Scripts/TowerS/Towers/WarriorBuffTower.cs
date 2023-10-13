using UnityEngine;

[RequireComponent(typeof(WarriorBuffTowerBehavoir))]
public class WarriorBuffTower : Tower
{
    private const float _damage1 = 10;
    private const float _damage2 = 15;
    private const float _damage3 = 20;

    private const float _armor1 = 0.3f;
    private const float _armor2 = 0.5f;
    private const float _armor3 = 0.7f;

    private WarriorBuffTowerBehavoir _tower;

    protected override void UpgradeLevelOne()
    {
        _tower = GetComponent<WarriorBuffTowerBehavoir>();

        _tower.SetBonuses(_damage1, _armor1);
    }

    protected override void UpgradeLevelTwo()
    {
        _tower.SetBonuses(_damage2, _armor2);
    }

    protected override void UpgradeLevelThree()
    {
        _tower.SetBonuses(_damage3, _armor3);

        base.UpgradeLevelThree();
    }
}
