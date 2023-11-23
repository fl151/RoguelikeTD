using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharecterInfoVeiw : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _info;
    [SerializeField] private PlatformsController _platformsController;

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
        var info = _platformsController.CurrentInfo;

        _name.text = info.Name;
        _info.text = info.Info;
    }
}
