using UnityEngine;

public class PauseButton : DefaultButton
{
    [SerializeField] private GameObject _myCanvas;
    [SerializeField] private GameObject _pauseCanvas;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        PauseManager.Instance.Pause();

        _pauseCanvas.SetActive(true);
        _myCanvas.SetActive(false);
    }
}
