using UnityEngine;

[CreateAssetMenu(fileName = "UpAttackSpeedUpgrade", menuName = "Upgrade/UpAttackSpeed", order = 51)]
public class UpAttackSpeedUpgrade : PlayerUpgrade
{
    public override void Realize()
    {
        UpgradesRealizator.Instance.UpgradePlayer(this);
    }
}
