using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private int _count;
    [SerializeField] private Transform _conteiner;

    private List<Bullet> _bullets = new List<Bullet>();

    private void Awake()
    {
        for (int i = 0; i < _count; i++)
        {
            Bullet bullet = Instantiate(_prefab, _conteiner);
            bullet.gameObject.SetActive(false);

            _bullets.Add(bullet);
        }
    }

    public bool TryGetBullet(out Bullet bullet)
    {
        bullet = _bullets.First(p => p.gameObject.activeSelf == false);

        return bullet != null;
    }
}
