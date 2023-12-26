using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharecterInfoVeiw : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _info;
    [SerializeField] private PlatformsController _platformsController;

    private CharecterInfo _currentInfo;

    private void OnEnable()
    {
        _platformsController.SwipeFinished += OnPlatformChanged;
    }

    private void OnDisable()
    {
        _platformsController.SwipeFinished -= OnPlatformChanged;
    }

    private void OnPlatformChanged()
    {
        UpdateView();
    }

    private void UpdateView()
    {
        if(_currentInfo != null)
        {
            _currentInfo.InfoChanged -= OnInfoChanged;
            _currentInfo.NameChanged -= OnNameChanged;
        }

        _currentInfo = _platformsController.CurrentInfo;

        _name.text = _currentInfo.Name;
        _info.text = _currentInfo.Info;

        _currentInfo.InfoChanged += OnInfoChanged;
        _currentInfo.NameChanged += OnNameChanged;
    }

    private void OnNameChanged(string name)
    {
        _name.text = name;
    }

    private void OnInfoChanged(string info)
    {
        _info.text = info;
    }
}
