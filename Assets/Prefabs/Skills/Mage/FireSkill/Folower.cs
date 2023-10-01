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
        if (_target == null) return;

        transform.position = _target.position;
    }
}
