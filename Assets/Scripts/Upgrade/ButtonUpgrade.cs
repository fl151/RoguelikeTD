using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Upgrade))]
public class ButtonUpgrade : DefaultButton
{
    private Upgrade _upgrade;

    private void Awake()
    {
        _upgrade = GetComponent<Upgrade>();
    }

    protected override void OnButtonClick()
    {
        _upgrade.Realize();
    }
}
