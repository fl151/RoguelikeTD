using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TryAgainButton : DefaultButton
{
    private const int _adChance = 50;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        int randomChance = Random.Range(0, 100);

        if (randomChance < _adChance)
            InterstitialAd.Show(OpenCallback, CloseCallback);
        else
            CloseCallback(true);
    }

    private void OpenCallback()
    {
        PauseManager.Instance.Pause();

        AudioListener.pause = true;
        AudioListener.volume = 0f;
    }

    private void CloseCallback(bool isClose)
    {
        AudioListener.pause = false;
        AudioListener.volume = 1f;

        PauseManager.Instance.Unpause();

        SceneManager.LoadScene(LevelsController.Instance.LevelSceneIndex);
    }

}
