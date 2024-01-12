using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TryAgainButton : DefaultButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        Time.timeScale = 1;
        SceneManager.LoadScene(LevelsController.Instance.LevelSceneIndex);
    }
}
