using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetBullet))]
public class RotateToTarget : MonoBehaviour
{
    private TargetBullet _bullet;

    private void Awake()
    {
        _bullet = GetComponent<TargetBullet>();
    }

    private void Update()
    {
        if(_bullet.Target != null)
        {
            Vector3 targetDir = _bullet.Target.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(targetDir + new Vector3(0, 90, 0));
        }
    }
}
