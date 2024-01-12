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

        _upgrade.TitleChanged += OnTitleChanged;

        _title.text = _upgrade.Title;
        _image.sprite = _upgrade.Sprite;

        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        _upgrade.TitleChanged -= OnTitleChanged;
    }

    private void OnButtonClick()
    {
        ButtonSoundPlayer.Instanse.Play();

        _upgrade.Realize();

        GetComponentInParent<Canvas>().gameObject.SetActive(false);
    }

    private void OnTitleChanged(string newTitle)
    {
        _title.text = newTitle;
    }
}
