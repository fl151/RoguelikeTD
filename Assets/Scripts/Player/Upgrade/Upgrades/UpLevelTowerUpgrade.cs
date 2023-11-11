using UnityEngine;

[CreateAssetMenu(fileName = "UpLevelTowerUpgrade", menuName = "Upgrade/UpLevelTower", order = 51)]
public class UpLevelTowerUpgrade : Upgrade
{
    public override void Realize()
    {
        UpgradesRealizator.Instance.UpLevelTowers(this);
    }
}
