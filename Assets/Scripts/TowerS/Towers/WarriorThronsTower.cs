using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ThronsBehavoir))]
public class WarriorThronsTower : Tower
{
    private ThronsBehavoir _throns;

    protected override void UpgradeLevelOne()
    {
        _throns = GetComponent<ThronsBehavoir>();
    }

    protected override void UpgradeLevelTwo()
    {
        
    }

    protected override void UpgradeLevelThree()
    {
        base.UpgradeLevelThree();
    }
}
