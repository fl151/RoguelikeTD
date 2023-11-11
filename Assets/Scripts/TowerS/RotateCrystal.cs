using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCrystal : MonoBehaviour
{
    [SerializeField] private int _rotateSpeed = 1;
    
    void Update()
    {
        transform.Rotate(0, _rotateSpeed, 0, Space.World);
    }
}
