using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas), typeof(UpgradesConteiner))]
public class UpgradesCanvas : MonoBehaviour
{
    private const int _countVariantsUpgrades = 3;

    [SerializeField] private Transform _panelParent;
    [SerializeField] private UpgradeView _buttonUpgradePrefab;
    [SerializeField] private UpgradesRealizator _realizator;

    private UpgradesConteiner _conteiner;

    private void Awake()
    {
        _conteiner = GetComponent<UpgradesConteiner>();
    }

    public void Fill(UpgradeBranch branch)
    {
        var charecterUpgrades = _conteiner.GetCharecterUpgrades(branch, Charecter.Mage);
        var defaultUpgrades = _conteiner.GetDefaultUpgrades(branch);

        var upgrades = GetMergetArray(charecterUpgrades, defaultUpgrades);

        for (int i = 0; i < _countVariantsUpgrades; i++)
        {
            var view =  Instantiate(_buttonUpgradePrefab, _panelParent);
            view.Fill(GetRandomUpgrade(upgrades));
        }
    }

    private Upgrade GetRandomUpgrade(Upgrade[] upgradeVariants)
    {
        int index = Random.Range(0, upgradeVariants.Length);

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
}