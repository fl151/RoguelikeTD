using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoView : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void Fill(KeyValuePair<Level, bool> levelInfo)
    {
        _image.sprite = levelInfo.Key.Icon;
    }
}
