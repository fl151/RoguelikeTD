using UnityEngine;

[CreateAssetMenu(fileName = "CriticalAttackUpgrade", menuName = "Upgrade/CriticalAttack", order = 51)]
public class CriticalAttackUpgrade : PlayerUpgrade
{
    public override void Realize()
    {
        UpgradesRealizator.Instance.UpgradePlayer(this);
    }
}
