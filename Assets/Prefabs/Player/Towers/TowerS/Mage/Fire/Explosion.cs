using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private const float _explosionTime = 0.6f;

    private void Awake()
    {
        Destroy(gameObject, _explosionTime);
    }
}
