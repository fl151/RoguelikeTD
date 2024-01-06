using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TargetWindow { Menu, Settings }


public class OpenSettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingsCanvas;
    [SerializeField] private GameObject _menuCanvas;

    [SerializeField] private TargetWindow _target;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if(_target == TargetWindow.Menu)
        {
            _menuCanvas.SetActive(true);
            _settingsCanvas.SetActive(false);
        }
        else if(_target == TargetWindow.Settings)
        {
            _settingsCanvas.SetActive(true);
            _menuCanvas.SetActive(false);
        }
    }
}
