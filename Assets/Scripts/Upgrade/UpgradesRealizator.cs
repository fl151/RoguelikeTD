using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesRealizator : MonoBehaviour
{
    public static UpgradesRealizator Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpDamage()
    {
    }
}
