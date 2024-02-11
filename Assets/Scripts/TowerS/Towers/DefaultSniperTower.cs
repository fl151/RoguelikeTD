using UnityEngine;

[RequireComponent(typeof(SniperTowerBehavoir))]
public class DefaultSniperTower : Tower
{
    private const float _damage1 = 100;
    private const float _damage2 = 200;
    private const float _damage3 = 400;

    private const float _attackSpeed1 = 0.3f;
    private const float _attackSpeed2 = 0.5f;
    private const float _attackSpeed3 = 0.7f;

    private const float _attackRange1 = 7;
    private const float _attackRange2 = 10;
    private const float _attackRange3 = 15;//Range-��� ���������

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
