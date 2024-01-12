using UnityEngine;
using UnityEngine.UI;

public class FindLevelButton : DefaultButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        FindLevelController.Instance.FindLevel();
    }
}
