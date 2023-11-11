using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : TargetBullet
{
    [SerializeField] private IceDebuff _iceDebuff;

    private float _slowCoef;

    public void SetSlowCoefficient(float value)
    {
        _slowCoef = value;
    }

    protected override void ActionHitEffect(EnemyHealth enemyTarget)
    {
        var debuff = enemyTarget.GetComponentInChildren<IceDebuff>();

        if (debuff != null)
        {
            debuff.Finish();
        }

        IceDebuff newDebuff = Instantiate(_iceDebuff, enemyTarget.transform);
        newDebuff.SetSlowCoefficient(_slowCoef);
    }
}
