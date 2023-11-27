using UnityEngine;
using UnityEngine.UI;

public class LevelInfoView : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
