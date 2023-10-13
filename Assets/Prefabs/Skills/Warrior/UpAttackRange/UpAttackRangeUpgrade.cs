using UnityEngine;

[CreateAssetMenu(fileName = "UpAttackRangeUpgrade", menuName = "Upgrade/UpAttackRange", order = 51)]
public class UpAttackRangeUpgrade : PlayerUpgrade
{
    public override void Realize()
    {
        UpgradesRealizator.Instance.UpgradePlayer(this);
    }
}
