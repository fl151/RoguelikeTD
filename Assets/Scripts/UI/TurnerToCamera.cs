using UnityEngine;

public class TurnerToCamera : MonoBehaviour
{
    private void Update()
    {
        var camera = Camera.current;

        if(camera != null)
        {
            transform.LookAt(camera.transform);
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
