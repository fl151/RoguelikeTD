using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade/UpDamage", order = 51)]
public class UpDamageUpgrade : Upgrade
{
    public override void Realize()
    {
        UpgradesRealizator.Instance.UpDamage();
    }
}
