using UnityEngine;

[RequireComponent(typeof(ThronsBehavoir))]
public class WarriorThronsTower : Tower
{
    private const float _damage1 = 10;
    private const float _damage2 = 20;
    private const float _damage3 = 30;

    private const float _slow1 = 0.3f;
    private const float _slow2 = 0.4f;
    private const float _slow3 = 0.5f;

    private ThronsBehavoir _throns;

    protected override void UpgradeLevelOne()
    {
        _throns = GetComponent<ThronsBehavoir>();

        _throns.SetStats(_damage1, _slow1);
    }

    protected override void UpgradeLevelTwo()
    {
        _throns.SetStats(_damage2, _slow2);
    }

    protected override void UpgradeLevelThree()
    {
        _throns.SetStats(_damage3, _slow3);

        base.UpgradeLevelThree();
    }
}
