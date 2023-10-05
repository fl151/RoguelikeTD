using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplosionBullet : PointBullet
{
    private const float _g = 15f;

    [SerializeField] private Explosion _explosionEffect;

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

        StartCoroutine(ExploseAfterTime(_t1 + _t2));
    }

    private void Update()
    {
        var direction = new Vector3(_Vx, _Vy, _Vz);

        transform.position += direction * Time.deltaTime;

        _Vy -= _g * Time.deltaTime;
    }

    private IEnumerator ExploseAfterTime(float flyTime)
    {
        yield return new WaitForSeconds(flyTime);

        Explosion effect = Instantiate(_explosionEffect, null);
        effect.transform.position = transform.position;

        Damage();

        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }

    private void Damage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius);

        var enemyes = from hit in hitColliders
                      where hit.TryGetComponent(out EnemyHealth enemy)
                      select hit.GetComponent<EnemyHealth>();

        foreach (var enemy in enemyes)
        {
            enemy.TakeDamage(_damage);
        }
    }
}
