using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Tower : MonoBehaviour
{
    protected int _currentLevel = 1;

    public abstract void UpdateTower();
}
