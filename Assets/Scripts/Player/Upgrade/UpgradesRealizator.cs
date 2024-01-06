using UnityEngine;
using UnityEngine.Events;

public class UpgradesRealizator : MonoBehaviour
{
    [SerializeField] private TowerSpawner _towerSpawner;
    [SerializeField] private PlayerTowers _playerTowers;

    private PlayerUpgrades _playerUpgrades;

    public static UpgradesRealizator Instance;
    public event UnityAction SomeBuffed;

    private void Awake()
    {
        if (Instance == null)
        {
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
        SomeBuffed?.Invoke();
    }

    public void BuildTower(Tower tower)
    {
        _towerSpawner.StartBuild(tower);
    }

    public void UpLevelTowers(UpLevelTowerUpgrade upgrade)
    {
        _playerTowers.UpLevelTowers(upgrade);
        SomeBuffed?.Invoke();
    }
}
