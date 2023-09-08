using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ButtonUpgrade), typeof(UpgradeView))]
public abstract class Upgrade : MonoBehaviour
{
    private ButtonUpgrade _button;

    protected abstract void Realize();

    private void Awake()
    {
        _button = GetComponent<ButtonUpgrade>();
    }

    private void OnEnable()
    {
        _button.OnButtonClicked += OnButtonClicked;
    }

    private void OnDisable()
    {
        _button.OnButtonClicked -= OnButtonClicked;
    }

    private void OnButtonClicked()
    {
        Realize();
    }
}
