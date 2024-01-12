using UnityEngine;

public class ChooseCharecterButton : DefaultButton
{
    [SerializeField] private CharecterType _charecter;

    private CharecterCanvas _charecterCanvas;

    private void Start()
    {
        _charecterCanvas = GetComponentInParent<CharecterCanvas>();
    }

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        _charecterCanvas.SetCharecter(_charecter);
    }
}
