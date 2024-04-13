using UnityEngine;

[RequireComponent(typeof(BuffHelpersTowerBehavoir))]
public class SummBuffTower : Tower
{
    private const float _damageBonus1 = 10;
    private const float _damageBonus2 = 13;
    private const float _damageBonus3 = 16;

    private BuffHelpersTowerBehavoir _tower;

    protected override void UpgradeLevelOne()
    {
        _tower = GetComponent<BuffHelpersTowerBehavoir>();
        _tower.SetDamageBonus(_damageBonus1);
    }

    protected override void UpgradeLevelTwo()
    {
        _tower.SetDamageBonus(_damageBonus2);
    }

    protected override void UpgradeLevelThree()
    {
        _tower.SetDamageBonus(_damageBonus3);

        base.UpgradeLevelThree();
    }
}
