using UnityEngine;
using UnityEngine.UI;

public class VolumeButton : DefaultButton
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _spriteOn;
    [SerializeField] private Sprite _spriteOff;

    private bool _isVolumeActive = true;
    private float _currentVolume = 1f;

    protected override void OnButtonClick()
    {
        if (_isVolumeActive) OffVolume();
        else OnVolume();

        base.OnButtonClick();
    }

    public void SetVolume(float value)
    {
        if (_currentVolume > 0 && value == 0) OffVolume();
        if (value > _currentVolume && _isVolumeActive == false) OnVolume();

        if (value != 0)
            _currentVolume = value;
    }

    private void OffVolume()
    {
        _slider.value = 0;
        _isVolumeActive = false;
        _image.sprite = _spriteOff;
    }

    private void OnVolume()
    {
        _slider.value = _currentVolume;
        _isVolumeActive = true;
        _image.sprite = _spriteOn;
    }
}
