using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagickSphereSkill : Skill
{
    [SerializeField] private SpheresController _spheres;

    [SerializeField] private float _damage1;
    [SerializeField] private float _damage2;
    [SerializeField] private float _damage3;

    protected override void UpgradeLevelOne()
    {
        _spheres.gameObject.SetActive(true);
        _spheres.Init(transform);
        _spheres.SetDamage(_damage1);
        _spheres.SetEffect(0);
    }

    protected override void UpgradeLevelTwo()
    {
        _spheres.SetDamage(_damage2);
        _spheres.SetEffect(1);
    }

    protected override void UpgradeLevelThree()
    {
        _spheres.SetDamage(_damage3);
        _spheres.SetEffect(2);

        base.UpgradeLevelThree();
    }
}
