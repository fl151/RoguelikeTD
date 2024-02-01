using UnityEngine;

public class ContinueButton : DefaultButton
{
    [SerializeField] private GameObject _myCanvas;
    [SerializeField] private GameObject _gameCanvas;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        PauseManager.Instance.Unpause();

        _gameCanvas.SetActive(true);
        _myCanvas.SetActive(false);
    }
}
