using UnityEngine;

public class ColorEffect
{
    private Color _color;
    private float _lifeTime;
    private int _order;

    public Color Color => _color;
    public float LifeTime => _lifeTime;
    public int Order => _order;

    public ColorEffect(Color color, float lifeTime, int order)
    {
        _color = color;
        _lifeTime = lifeTime;
        _order = order;
    }

    public void ReduceTime(float time)
    {
        _lifeTime -= time;
    }
}
