using UnityEngine;

[RequireComponent(typeof(SniperTowerBehavoir))]
public class DefaultSniperTower : Tower
{
    private const float _damage1 = 300;
    private const float _damage2 = 600;
    private const float _damage3 = 900;

    private const float _attackSpeed1 = 0.7f;
    private const float _attackSpeed2 = 0.9f;
    private const float _attackSpeed3 = 1.2f;

    private const float _attackRange1 = 7;
    private const float _attackRange2 = 9;
    private const float _attackRange3 = 12;//Range-это дальность

    private SniperTowerBehavoir _tower;

    protected override void UpgradeLevelOne()
    {
        _tower = GetComponent<SniperTowerBehavoir>();
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
