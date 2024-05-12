using System.Collections;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.SceneManagement;
//using Lean.Localization;


public class LoadSdк : MonoBehaviour
{
    //[SerializeField] private LeanLocalization _leanLocalization;

    //private const string EnglishLanguage = "en";
    //private const string RussionLanguage = "ru";
    //private const string TurkishLanguage = "tr";


    private void Awake()
    {
        StartCoroutine(LoadYandexSdk());
    }

    private IEnumerator LoadYandexSdk()
    {
        yield return new WaitForSeconds(2f);
        yield return YandexGamesSdk.Initialize(() => SetLeanguage());        
    }

    private void SetLeanguage()
    {
        //switch (YandexGamesSdk.Environment.i18n.lang)
        //{
            //case EnglishLanguage:
                //_leanLocalization.CurrentLanguage = Lenguage.English;
                //break;

            //case RussionLanguage:
               // _leanLocalization.CurrentLanguage = Lenguage.Russian;
                //break;

            //case TurkishLanguage:
               // _leanLocalization.CurrentLanguage = Lenguage.Turkish;
                //break;

            //default:
                //_leanLocalization.CurrentLanguage = Lenguage.Russian;
                //break;
        //}

        SceneManager.LoadScene(1);
    }
}