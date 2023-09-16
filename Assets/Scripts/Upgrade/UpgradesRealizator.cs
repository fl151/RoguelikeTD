using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesRealizator : MonoBehaviour
{
    [SerializeField] private TowerSpawner _towerSpawner;
    [SerializeField] private PlayerTowers _playerTowers;

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
    }

    public void UpDamage()
    {
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
