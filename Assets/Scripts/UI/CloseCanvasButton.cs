using UnityEngine;

public class CloseCanvasButton : DefaultButton
{
    [SerializeField] private GameObject _canvas;

    protected override void OnButtonClick()
    {
        _canvas.SetActive(false);

        base.OnButtonClick();
    }
}
