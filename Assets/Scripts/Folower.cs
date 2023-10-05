using UnityEngine;

public class Folower : MonoBehaviour
{
    private Transform _target;

    public bool IsTargetActive => _target.gameObject.activeSelf;

    private void OnEnable()
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
