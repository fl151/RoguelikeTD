using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTowers : MonoBehaviour
{
    [SerializeField] private TowerSpawner _spawner;

    private List<Tower> _towers = new List<Tower>();
    private List<Upgrade> _upgrades = new List<Upgrade>();

    private void OnEnable()
    {
        _spawner.Build += AddTower;
    }

    private void OnDisable()
    {
        _spawner.Build -= AddTower;
    }

    public void AddTower(Tower tower)
    {
        _towers.Add(tower);

        if (_upgrades.Contains(tower.TowerUpgrade) == false)
            _upgrades.Add(tower.TowerUpgrade);
    }

    public void UpLevelTowers(Upgrade upgrade)
    {
        foreach (var tower in _towers)
        {
            if (tower.TowerUpgrade == upgrade)
                tower.UpdateTower();
        }
    }

    public Upgrade[] GetUpgrades()
    {
        var upgrades = new Upgrade[_upgrades.Count];

        for (int i = 0; i < _upgrades.Count; i++)
        {
            upgrades[i] = _upgrades[i];
        }

        return upgrades;
    }
}
