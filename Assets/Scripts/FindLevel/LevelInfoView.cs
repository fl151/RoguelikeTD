using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _block;
    [SerializeField] private GameObject _active;

    private Button _button;
    private Level _level;

    public void Fill(KeyValuePair<Level, bool> levelInfo)
    {
        _level = levelInfo.Key;

        _image.sprite = levelInfo.Key.Icon;
        _button = GetComponent<Button>();
        _button.enabled = levelInfo.Value;
        _button.onClick.AddListener(OnButtonClicked);
        _block.SetActive(!levelInfo.Value);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
        FindLevelController.Instance.NewLevel -= MakeInactive;
    }

    private void OnButtonClicked()
    {
        if (FindLevelController.Instance.TrySetLevel(_level))
        {
            _active.SetActive(true);
            FindLevelController.Instance.NewLevel += MakeInactive;
        }
    }

    private void MakeInactive()
    {
        _active.SetActive(false);
        FindLevelController.Instance.NewLevel -= MakeInactive;
    }
}
