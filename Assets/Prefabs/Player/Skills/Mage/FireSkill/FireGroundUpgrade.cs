using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireGroundUpgrade", menuName = "Upgrade/FireGround", order = 51)]
public class FireGroundUpgrade : PlayerUpgrade
{
    public override void Realize()
    {
        UpgradesRealizator.Instance.UpgradePlayer(this);
    }
}
