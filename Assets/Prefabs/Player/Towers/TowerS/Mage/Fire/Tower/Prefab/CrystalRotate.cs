using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalRotate : MonoBehaviour
{
    [SerializeField] private GameObject _centre;
    [SerializeField] private Vector3 axis;

     private float _rotateSpeed = 0.5f;

    void Update()
    {
        transform.RotateAround(_centre.transform.position, axis, _rotateSpeed);
    }
}

