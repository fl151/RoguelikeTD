using System.Collections;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;


public class LoadSdк : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(LoadYandexSdk());
    }

    private IEnumerator LoadYandexSdk()
    {
        yield return YandexGamesSdk.Initialize(() => StartCoroutine(GetLocale()));        
    }

    private IEnumerator GetLocale()
    {
        yield return LocalizationSettings.InitializationOperation;

        var language = YandexGamesSdk.Environment.browser.lang;

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(language);

        SceneManager.LoadScene(1);
    }
}