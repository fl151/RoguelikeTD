using UnityEngine;

[CreateAssetMenu(fileName = "UpDamageUpgrade", menuName = "Upgrade/UpDamage", order = 51)]
public class UpDamageUpgrade : PlayerUpgrade
{
    public override void Realize()
    {
        UpgradesRealizator.Instance.UpgradePlayer(this);
    }
}
