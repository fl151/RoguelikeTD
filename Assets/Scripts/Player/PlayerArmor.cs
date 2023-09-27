using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    [SerializeField] private float _armor = 0;

    public float Armor => Mathf.Clamp01(_armor);

    public void AddArmor(float value)
    {
        _armor += value;
    }
}
