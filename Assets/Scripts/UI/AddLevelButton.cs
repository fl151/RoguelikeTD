using UnityEngine;

public class AddLevelButton : DefaultButton
{
    [SerializeField] private GameObject _myCanvas;
    [SerializeField] private GameObject _addLevelCanvas;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        PauseManager.Instance.Pause();

        _addLevelCanvas.SetActive(true);
        _myCanvas.SetActive(false);
    }
}
