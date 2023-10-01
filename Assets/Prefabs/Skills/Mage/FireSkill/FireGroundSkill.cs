using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGroundSkill : Skill
{
    private const float _totalDamage1 = 200;
    private const float _totalDamage2 = 400;
    private const float _totalDamage3 = 800;

    private const float _scale1 = 0.5f;
    private const float _scale2 = 0.75f;
    private const float _scale3 = 0.9f;

    [SerializeField] private FireGrorund _fireGround;

    protected override void UpgradeLevelOne()
    {
        _fireGround.gameObject.SetActive(true);

        _fireGround.SetDamage(_totalDamage1);

        _fireGround.SetScale(_scale1);
    }

    protected override void UpgradeLevelTwo()
    {
        _fireGround.SetDamage(_totalDamage2);

        _fireGround.SetScale(_scale2);
    }

    protected override void UpgradeLevelThree()
    {
        _fireGround.SetDamage(_totalDamage3);

        _fireGround.SetScale(_scale3);

        base.UpgradeLevelThree();
    }
}
