using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacesControler : MonoBehaviour
{
    private TowerPlace[] _places;

    private void Awake()
    {
        _places = GetComponentsInChildren<TowerPlace>();
    }
}
