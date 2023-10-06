using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas), typeof(UpgradesConteiner))]
public class UpgradesCanvas : MonoBehaviour
{
    private const int _countVariantsUpgrades = 3;

    [SerializeField] private Transform _panelParent;
    [SerializeField] private UpgradeView _buttonUpgradePrefab;
    [SerializeField] private PlayerTowers _playerTowers;
    [SerializeField] private GameObject _errorUI;

    private UpgradesConteiner _conteiner;
    private PlayerCharecter _playerCharecter;
    private PlayerUpgrades _playerUpgrades;

    private UpgradeView[] _currentViews;

    private void Awake()
    {
        _conteiner = GetComponent<UpgradesConteiner>();
        _playerCharecter = _playerTowers.GetComponent<PlayerCharecter>();
        _playerUpgrades = _playerTowers.GetComponent<PlayerUpgrades>();
        _currentViews = new UpgradeView[_countVariantsUpgrades];
    }

    private void OnEnable()
    {
        _errorUI.SetActive(false);
    }

    public void Fill(UpgradeBranch branch)
    {
        DestroyOldViews();

        Upgrade[] upgrades = new Upgrade[0];

        switch (branch) {
            case UpgradeBranch.Player:
                upgrades = _playerUpgrades.ValidPlayerUpgrades;
                break;

            case UpgradeBranch.Towers:
                upgrades = GetTowersUpgrades();
                break;
        }

        if(upgrades.Length == 0)
        {
            _errorUI.SetActive(true);
        }
        else
        {
            var upgradesList = ConverToList(upgrades);

            for (int i = 0; i < _countVariantsUpgrades; i++)
            {
                if (upgradesList.Count == 0) return;

                var view = Instantiate(_buttonUpgradePrefab, _panelParent);
                var upgrade = GetRandomUpgrade(upgradesList);
                view.Fill(upgrade);

                upgradesList.Remove(upgrade);

                _currentViews[i] = view;
            }
        }
    }

    private Upgrade[] GetTowersUpgrades()
    {
        var towerUpgrades = _playerTowers.GetUpgrades();
        var towerBuildUpgrades = GetMergetArray(
            _conteiner.GetCharecterUpgrades(UpgradeBranch.Towers, _playerCharecter.Charecter),
            _conteiner.GetDefaultUpgrades(UpgradeBranch.Towers));

        var upgrades = GetMergetArray(towerUpgrades, towerBuildUpgrades);

        return upgrades;
    }

    private Upgrade GetRandomUpgrade(List<Upgrade> upgradeVariants)
    {
        if (upgradeVariants.Count == 0) return null;

        int index = Random.Range(0, upgradeVariants.Count);

        return upgradeVariants[index];
    }

    private Upgrade[] GetMergetArray(Upgrade[] array1, Upgrade[] array2)
    {
        Upgrade[] result = new Upgrade[array1.Length + array2.Length];

        for (int i = 0; i < array1.Length; i++)
        {
            result[i] = array1[i];
        }

        for (int i = 0; i < array2.Length; i++)
        {
            result[array1.Length + i] = array2[i];
        }

        return result;
    }

    private void DestroyOldViews()
    {
        for (int i = 0; i < _currentViews.Length; i++)
            if (_currentViews[i] != null)
                Destroy(_currentViews[i].gameObject);
    }

    private List<Upgrade> ConverToList(Upgrade[] upgrades)
    {
        List<Upgrade> upgradesList = new List<Upgrade>();

        foreach (var upgrade in upgrades)
        {
            upgradesList.Add(upgrade);
        }

        return upgradesList;
    }
}
