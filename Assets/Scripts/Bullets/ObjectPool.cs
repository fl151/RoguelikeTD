using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _count;
    [SerializeField] private Transform _conteiner;

    private List<GameObject> _objects = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < _count; i++)
        {
            GameObject obj = Instantiate(_prefab, _conteiner);
            obj.gameObject.SetActive(false);

            _objects.Add(obj);
        }
    }

    public bool TryGetObject(out GameObject obj)
    {
        obj = _objects.First(p => p.gameObject.activeSelf == false);

        return obj != null;
    }
}
