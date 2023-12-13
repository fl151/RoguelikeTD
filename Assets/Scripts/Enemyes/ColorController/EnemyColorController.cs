using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyColorController : MonoBehaviour
{
    private Color _defaultColor = Color.white;

    private List<ColorEffect> _colorEffects = new List<ColorEffect>();

    private ColorEffect _currentEffect;

    private SkinnedMeshRenderer _skin;

    private void Awake()
    {
        _skin = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    private void OnEnable()
    {
        SetNewCurrentEffect(null);
        ClearList();
    }

    private void Update()
    {
        TickEffects();
        DeleteFinishedEffects();

        if (_currentEffect != null)
            if (_currentEffect.LifeTime <= 0)
                SetNewCurrentEffect(GetNewEffect());
    }

    public void AddEffect(ColorEffect colorEffect)
    {
        _colorEffects.Add(colorEffect);

        if(_currentEffect == null)
        {
            SetNewCurrentEffect(colorEffect);
        }
        else
        {
            if (_currentEffect.Order <= colorEffect.Order)
            {
                SetNewCurrentEffect(colorEffect);
            }
        }
    }

    private void TickEffects()
    {
        var reduseTime = Time.deltaTime;

        foreach (var colorEffect in _colorEffects)
        {
            colorEffect.ReduceTime(reduseTime);
        }
    }

    private void DeleteFinishedEffects()
    {
        for (int i = 0; i < _colorEffects.Count;)
        {
            if (_colorEffects[i].LifeTime <= 0)
                _colorEffects.Remove(_colorEffects[i]);
            else
                i++;
        }
    }

    private ColorEffect GetNewEffect()
    {
        int maxOrder = int.MinValue;
        ColorEffect result = null;

        foreach (var colorEffect in _colorEffects)
        {
            if (colorEffect.Order >= maxOrder)
            {
                maxOrder = colorEffect.Order;
                result = colorEffect;
            }
        }

        return result;
    }

    private void SetNewCurrentEffect(ColorEffect colorEffect)
    {
        _currentEffect = colorEffect;

        if (_currentEffect == null)
            SetColor(_defaultColor);
        else
            SetColor(_currentEffect.Color);
    }

    private void SetColor(Color color)
    {
        _skin.material.color = color;
    }

    private void ClearList()
    {
        for (int i = 0; i < _colorEffects.Count;)
        {
            _colorEffects.Remove(_colorEffects[i]);
        }
    }
}
