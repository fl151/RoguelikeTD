using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : DefaultButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
