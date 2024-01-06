using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private const float _rotationSpeed = 2f;

    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
