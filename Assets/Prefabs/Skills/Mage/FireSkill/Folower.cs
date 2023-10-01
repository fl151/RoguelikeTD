using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folower : MonoBehaviour
{
    private Transform _target;

    private void Awake()
    {
        _target = transform.parent;

        transform.parent = null;
    }

    private void Update()
    {
        transform.position = _target.position;
    }
}
