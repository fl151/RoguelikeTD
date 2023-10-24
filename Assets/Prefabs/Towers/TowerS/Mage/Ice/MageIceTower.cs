using UnityEngine;

[RequireComponent(typeof(IceTowerBehavoir))]
public class MageIceTower : Tower
{
    private const float _damage1 = 30;
    private const float _damage2 = 50;
    private const float _damage3 = 100;

    private const float _attackSpeed1 = 1;
    private const float _attackSpeed2 = 1.5f;
    private const float _attackSpeed3 = 2f;

    private const float _slowCoefficient1 = 0.3f;
    private const float _slowCoefficient2 = 0.5f;
    private const float _slowCoefficient3 = 0.7f;

    private IceTowerBehavoir _tower;

    protected override void UpgradeLevelOne()
    {
        _tower = GetComponent<IceTowerBehavoir>();
        _tower.SetStats(_damage1, _attackSpeed1, _slowCoefficient1);
    }

    protected override void UpgradeLevelTwo()
    {
        _tower.SetStats(_damage2, _attackSpeed2, _slowCoefficient2);
    }

    protected override void UpgradeLevelThree()
    {
        _tower.SetStats(_damage3, _attackSpeed3, _slowCoefficient3);

        base.UpgradeLevelThree();
    }
}
