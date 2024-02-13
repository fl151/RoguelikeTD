using UnityEngine;

public class TurnerToCamera : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.current;        
    }

    private void Update()
    {
        if(_camera != null)
            transform.LookAt(_camera.transform);
    }
}
