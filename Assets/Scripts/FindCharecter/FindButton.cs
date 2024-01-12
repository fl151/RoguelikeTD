using UnityEngine;
using UnityEngine.SceneManagement;

public class FindButton : DefaultButton
{
    [SerializeField] private PlatformsController _platformsController;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        CharecterHolder.Instance.SetCharecter(_platformsController.CurrentCharecter);

        SceneManager.LoadScene(LevelsController.Instance.LevelSceneIndex);
    }
}
