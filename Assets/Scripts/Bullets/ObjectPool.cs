using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T _prefab;
    private Transform _conteiner;
    private bool _autoExpand;

    private List<T> _objects;

    public ObjectPool(T prefab, int count, bool autoExpand)
    {
        _prefab = prefab;
        _conteiner = null;
        _autoExpand = autoExpand;

        InitPool(count);
    }

    public ObjectPool(T prefab, int count, Transform conteiner, bool autoExpand)
    {
        _prefab = prefab;
        _conteiner = conteiner;
        _autoExpand = autoExpand;

        InitPool(count);
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var obj in _objects)
        {
            if (obj.gameObject.activeSelf == false)
            {
                element = obj;
                element.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if(HasFreeElement(out var element))
            return element;

        if (_autoExpand)
            return CreateObject(true);

        throw new Exception($"no element in pool {typeof(T)}");
    }

    private void InitPool(int count)
    {
        _objects = new List<T>();

        for (int i = 0; i < count; i++)
            CreateObject();
    }

    private T CreateObject(bool isActive = false)
    {
        T obj = UnityEngine.Object.Instantiate(_prefab, _conteiner);
        obj.gameObject.SetActive(isActive);
        _objects.Add(obj);

        return obj;
    }

    
}
