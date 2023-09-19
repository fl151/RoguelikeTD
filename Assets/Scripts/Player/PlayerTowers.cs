using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

        foreach (var tower in _towers)
        {
            tower.MaxLevel -= RemoveTowerFromList;
        }
    }

    public void AddTower(Tower tower)
    {
        _towers.Add(tower);

        tower.MaxLevel += RemoveTowerFromList;

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

    public int GetCurrentTowerLevel(Tower tower)
    {
        int level = 0;

        if (_upgrades.Contains(tower.TowerUpgrade))
        {
            var result = from Tower resultTower in _towers
                         select resultTower.CurrentLevel;

            level = result.First();
        }

        return level;   
    }

    private void RemoveTowerFromList(Upgrade upgrade)
    {
        _upgrades.Remove(upgrade);

        var towers = new List<Tower>();

        foreach (var tower in _towers)
        {
            if (tower.TowerUpgrade != upgrade)
                towers.Add(tower);
            else
                tower.MaxLevel -= RemoveTowerFromList;
        }

        _towers = towers;
    }
}
