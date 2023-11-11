using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalAttackSkill : Skill
{
    private const float _chance1 = 0.1f;
    private const float _chance2 = 0.25f;
    private const float _chance3 = 0.33f;

    private const float _damageScale1 = 1.3f;
    private const float _damageScale2 = 1.5f;
    private const float _damageScale3 = 2f;

    private HeroMeeleAttack _heroAttack;

    protected override void UpgradeLevelOne()
    {
        _heroAttack = GetComponentInParent<HeroMeeleAttack>();

        _heroAttack.SetCriticalStats(_chance1, _damageScale1);
    }

    protected override void UpgradeLevelTwo()
    {
        _heroAttack.SetCriticalStats(_chance2, _damageScale2);
    }

    protected override void UpgradeLevelThree()
    {
        _heroAttack.SetCriticalStats(_chance3, _damageScale3);

        base.UpgradeLevelThree();
    }
}
