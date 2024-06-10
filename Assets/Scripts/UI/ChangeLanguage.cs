using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class ChangeLanguage : DefaultButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale("tr");
        
    }
}
