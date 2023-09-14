using UnityEngine;

[CreateAssetMenu(fileName = "UpDamageUpgrade", menuName = "Upgrade/UpDamage", order = 51)]
public class UpDamageUpgrade : Upgrade
{
    public override void Realize()
    {
        UpgradesRealizator.Instance.UpDamage();
    }
}
