using UnityEngine;

public class BackToChooseBranchButton : DefaultButton
{
    [SerializeField] private GameObject _chooseBranchCanvas;
    [SerializeField] private GameObject _upgradesCanvas;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        _chooseBranchCanvas.SetActive(true);
        _upgradesCanvas.SetActive(false);
    }
}
