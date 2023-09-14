using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildTowerUpgrade", menuName = "Upgrade/BuildTower", order = 51)]
public class BuildTowerUpgrade : Upgrade
{
    [SerializeField] private Tower _prefab;

    public override void Realize()
    {
        UpgradesRealizator.Instance.BuildTower(_prefab);
    }
}
