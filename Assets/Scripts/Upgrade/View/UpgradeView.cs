using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    [SerializeField] private ViewData _data;

    private void Start()
    {
        _text.text = _data.Title;
        _image.sprite = _data.Sprite;
    }
}
