using UnityEngine;

public class UpgradesConteiner : MonoBehaviour
{
    [SerializeField] private Upgrade[] _magePlayerUpgrades;
    [SerializeField] private Upgrade[] _warriorPlayerUpgrades;
    [SerializeField] private Upgrade[] _summonerPlayerUpgrades;

    [SerializeField] private Upgrade[] _mageTowerUpgrades;
    [SerializeField] private Upgrade[] _warriorTowerUpgrades;
    [SerializeField] private Upgrade[] _summonerTowerUpgrades;

    [SerializeField] private Upgrade[] _defaultPlayerUpgrades;
    [SerializeField] private Upgrade[] _defaultTowerUpgrades;

    private Upgrade[,][] _upgrades = new Upgrade[2, 3][];

    private void Awake()
    {
        _upgrades[0, 0] = _magePlayerUpgrades;
        _upgrades[0, 1] = _warriorPlayerUpgrades;
        _upgrades[0, 2] = _summonerPlayerUpgrades;

        _upgrades[1, 0] = _mageTowerUpgrades;
        _upgrades[1, 1] = _warriorTowerUpgrades;
        _upgrades[1, 2] = _summonerTowerUpgrades;
    }

    public Upgrade[] GetCharecterUpgrades(UpgradeBranch branch, Charecter charecter)
    {
        var currentUpgrades = _upgrades[(int)branch, (int)charecter];

        Upgrade[] upgrades = new Upgrade[currentUpgrades.Length];

        for (int i = 0; i < currentUpgrades.Length; i++)
        {
            upgrades[i] = currentUpgrades[i];
        }

        return upgrades;
    }

    public Upgrade[] GetDefaultUpgrades(UpgradeBranch branch)
    {
        Upgrade[] currentUpgrades = default;

        switch (branch) {
            case UpgradeBranch.Player:
                currentUpgrades = _defaultPlayerUpgrades;
                break;

            case UpgradeBranch.Towers:
                currentUpgrades = _defaultTowerUpgrades;
                break;
        }

        Upgrade[] upgrades = new Upgrade[currentUpgrades.Length];

        for (int i = 0; i < currentUpgrades.Length; i++)
        {
            upgrades[i] = currentUpgrades[i];
        }

        return upgrades;
    }
}
