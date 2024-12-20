using UnityEngine;

public class AuthButton : DefaultButton
{
    [SerializeField] private GameObject _canvas;

    protected override void OnButtonClick()
    {
        Web.AuthAccount();

        _canvas.SetActive(false);

        base.OnButtonClick();
    }
}
