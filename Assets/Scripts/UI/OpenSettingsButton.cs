using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TargetWindow { Menu, Settings }

public class OpenSettingsButton : DefaultButton
{
    [SerializeField] private GameObject _settingsCanvas;
    [SerializeField] private GameObject _menuCanvas;

    [SerializeField] private TargetWindow _target;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        if (_target == TargetWindow.Menu)
        {
            _menuCanvas.SetActive(true);
            _settingsCanvas.SetActive(false);
        }
        else if (_target == TargetWindow.Settings)
        {
            _settingsCanvas.SetActive(true);
            _menuCanvas.SetActive(false);
        }
    }
}
