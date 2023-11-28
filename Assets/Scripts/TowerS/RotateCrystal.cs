using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCrystal : MonoBehaviour
{
    [SerializeField] private int _rotateSpeed = 1;

    private int xAngle = 0;
    private int zAngle = 0;

    void Update()
    {
        transform.Rotate(xAngle, _rotateSpeed, zAngle, Space.World);
    }
}
