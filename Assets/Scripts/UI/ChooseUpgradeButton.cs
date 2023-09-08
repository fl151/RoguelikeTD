using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeBranch {
    Player,
    Towers
}

public class ChooseUpgradeButton : DefaultButton
{
    [SerializeField] private UpgradeBranch _upgradeBranch;
    [SerializeField] private UpgradesCanvas _upgradesCanvas;
    [SerializeField] private GameObject _currentCanvas;

    protected override void OnButtonClick()
    {
        _upgradesCanvas.gameObject.SetActive(true);
        _upgradesCanvas.Fill(_upgradeBranch);

        _currentCanvas.SetActive(false);
    }
}
