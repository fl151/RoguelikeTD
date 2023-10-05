using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBullet : PointBullet
{
    private const float _g = 9.8f;

    private float _damage;
    private float _radius;
    private float _maxY;

    private float _L;
    private float _Vy;
    private float _vHorisontal;
    private float _Vx;
    private float _Vz;
    private float _t1;
    private float _t2;
    private float _sinAngle;
    private float _cosAngle;

    public void SetStats(float damage, float radius, float maxY)
    {
        _damage = damage;
        _radius = radius;
        _maxY = maxY;
    }

    public void SetTargetPoint(Vector3 point)
    {
        _L = (point -
            new Vector3(transform.position.x, point.y, transform.position.z)).magnitude;

        _sinAngle = (point.z - transform.position.z) / _L;
        _cosAngle = (point.x - transform.position.x) / _L;

        _Vy = Mathf.Sqrt(2 * _g * (_maxY - transform.position.y));

        _t1 = Mathf.Sqrt(2 * _g * (_maxY - transform.position.y)) / _g;

        _t2 = Mathf.Sqrt(2 * _maxY / _g);

        _vHorisontal = _L / (_t1 + _t2);

        _Vx = _vHorisontal * _cosAngle;
        _Vz = _vHorisontal * _sinAngle;

        StartCoroutine(Explose(_t1 + _t2));
    }

    private void Update()
    {
        Vector3 direction = new Vector3(_Vx, _Vy, _Vz);

        transform.position += direction * Time.deltaTime;

        _Vy -= _g * Time.deltaTime;
    }

    private void Explosion()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator Explose(float time)
    {
        yield return new WaitForSeconds(time);

        Explosion();
    }
}
