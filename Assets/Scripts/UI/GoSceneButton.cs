using UnityEngine;
using UnityEngine.SceneManagement;


public class GoSceneButton : DefaultButton
{
    [SerializeField] private int _targetSceneIndex;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        Time.timeScale = 1;
        SceneManager.LoadScene(_targetSceneIndex);
    }
}
