using UnityEngine;

public class PlacesControler : MonoBehaviour
{
    private TowerPlace[] _places;

    private void Awake()
    {
        _places = GetComponentsInChildren<TowerPlace>();
    }

    private void OnEnable()
    {
        foreach (var place in _places)
        {
            place.MakeActive();
        }
    }
}
