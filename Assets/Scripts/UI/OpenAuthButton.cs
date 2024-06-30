using UnityEngine;

public class OpenAuthButton : DefaultButton
{
    [SerializeField] private GameObject _authCanvas;

    protected override void OnButtonClick()
    {
        _authCanvas.SetActive(true);

        base.OnButtonClick();
    }
}
