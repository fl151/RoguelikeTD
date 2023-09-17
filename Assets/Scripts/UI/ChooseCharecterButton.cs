using UnityEngine;

public class ChooseCharecterButton : DefaultButton
{
    [SerializeField] private Charecter _charecter;

    private CharecterCanvas _charecterCanvas;

    private void Start()
    {
        _charecterCanvas = GetComponentInParent<CharecterCanvas>();
    }

    protected override void OnButtonClick()
    {
        _charecterCanvas.SetCharecter(_charecter);
    }
}
