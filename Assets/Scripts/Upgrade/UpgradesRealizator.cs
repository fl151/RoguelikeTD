using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesRealizator : MonoBehaviour
{
    [SerializeField] private TowerSpawner _towerSpawner;
    [SerializeField] private PlayerTowers _playerTowers;

    private PlayerUpgrades _playerUpgrades;

    public static UpgradesRealizator Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _playerUpgrades = _playerTowers.GetComponent<PlayerUpgrades>();
    }

    public void UpgradePlayer(PlayerUpgrade upgrade)
    {
        _playerUpgrades.UpLevelSkill(upgrade);
    }

    public void BuildTower(Tower tower)
    {
        _towerSpawner.StartBuild(tower);
    }

    public void UpLevelTowers(UpLevelTowerUpgrade upgrade)
    {
        _playerTowers.UpLevelTowers(upgrade);
    }
}
