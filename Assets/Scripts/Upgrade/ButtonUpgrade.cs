using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonUpgrade : DefaultButton
{
    public UnityAction OnButtonClicked;

    protected override void OnButtonClick()
    {
        OnButtonClicked?.Invoke();
    }
}
