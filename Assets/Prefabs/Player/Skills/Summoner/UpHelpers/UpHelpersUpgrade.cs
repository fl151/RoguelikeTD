using UnityEngine;

[CreateAssetMenu(fileName = "UpHelpersUpgrade", menuName = "Upgrade/UpHelpers", order = 51)]
public class UpHelpersUpgrade : PlayerUpgrade
{
    public override void Realize()
    {
        UpgradesRealizator.Instance.UpgradePlayer(this);
    }
}
