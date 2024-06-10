using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using System.Collections;

public class LanguageController : MonoBehaviour
{
    private const string _ruLang = "ru";
    private const string _trLang = "tr";
    private const string _enLang = "en";

    private const string _RuLang = "Russian";
    private const string _TrLang = "Turkish";
    private const string _EnLang = "English";

    public static LanguageController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        // ѕолучите доступ к локали после ее загрузки
        StartCoroutine(GetLocale());
    }

    private IEnumerator GetLocale()
    {
        // ќжидайте, пока локаль будет загружена
        yield return LocalizationSettings.InitializationOperation;

        Debug.Log("tr");
        var language = YandexGamesSdk.Environment.browser.lang;

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(language);

        SceneManager.LoadScene("Menu");
    }
}
