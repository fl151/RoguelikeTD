using UnityEngine;

[RequireComponent(typeof(MultyshotTowerBehavoir))]
public class DefaultMultishotTower : Tower
{
    private const float _damage1 = 150;
    private const float _damage2 = 225;
    private const float _damage3 = 300;

    private const float _attackSpeed1 = 0.6f;
    private const float _attackSpeed2 = 1f;
    private const float _attackSpeed3 = 1.4f;

    private const int _countAttacks1 = 2;
    private const int _countAttacks2 = 3;
    private const int _countAttacks3 = 4;

    private MultyshotTowerBehavoir _tower;

    protected override void UpgradeLevelOne()
    {
        _tower = GetComponent<MultyshotTowerBehavoir>();

        _tower.SetStats(_damage1, _attackSpeed1, _countAttacks1);
    }

    protected override void UpgradeLevelTwo()
    {
        _tower.SetStats(_damage2, _attackSpeed2, _countAttacks2);
    }

    protected override void UpgradeLevelThree()
    {
        _tower.SetStats(_damage3, _attackSpeed3, _countAttacks3);

        base.UpgradeLevelThree();
    }
}
