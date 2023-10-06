using UnityEngine;

public class Folower : MonoBehaviour
{
    private Transform _target;

    private Vector3 _startDistanse;

    public bool IsTargetActive => _target.gameObject.activeSelf;

    private void OnEnable()
    {
        _target = transform.parent;
        _startDistanse = transform.position - _target.position;

        transform.parent = null;
    }

    private void Update()
    {
        if (_target == null) return;

        transform.position = _target.position + _startDistanse;
    }
}
