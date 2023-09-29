using UnityEngine;

[CreateAssetMenu(fileName = "SummonUpgrade", menuName = "Upgrade/Summon", order = 51)]
public class SummonUpgrade : PlayerUpgrade
{
    public override void Realize()
    {
        UpgradesRealizator.Instance.UpgradePlayer(this);
    }
}
