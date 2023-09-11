using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] TMP_Text _title;
    [SerializeField] Image _image;
    

    private Upgrade _upgrade;
    public void Fill(Upgrade upgrade)
    {
        _upgrade = upgrade;

        _title.text = _upgrade.Title;
        _image.sprite = _upgrade.Sprite;

        _button.onClick.AddListener(_upgrade.Realize);
    }

    private void OnDestroy()
    {
        _button.onClick.AddListener(_upgrade.Realize);
    }
}
