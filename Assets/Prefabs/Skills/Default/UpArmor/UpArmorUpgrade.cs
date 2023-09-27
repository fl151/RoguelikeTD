using UnityEngine;

[CreateAssetMenu(fileName = "UpArmorUpgrade", menuName = "Upgrade/UpArmor", order = 51)]
public class UpArmorUpgrade : PlayerUpgrade
{
    public override void Realize()
    {
        UpgradesRealizator.Instance.UpgradePlayer(this);
    }
}
