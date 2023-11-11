using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagickShperesUpgrade", menuName = "Upgrade/MagickSpheres", order = 51)]
public class MagickSpheresUpgrade : PlayerUpgrade
{
    public override void Realize()
    {
        UpgradesRealizator.Instance.UpgradePlayer(this);
    }
}
