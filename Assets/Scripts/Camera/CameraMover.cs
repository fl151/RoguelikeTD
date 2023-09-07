using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] GameObject _target;

    private Vector3 _cameraLocalPosition;

    private void Start()
    {
        _cameraLocalPosition = transform.position - _target.transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position + _cameraLocalPosition, 0.02f);
    }
}
