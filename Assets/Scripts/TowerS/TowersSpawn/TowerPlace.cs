using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TowerPlace : MonoBehaviour
{
    [SerializeField] private GameObject _model;

    private bool _active;

    public bool Active => _active;

    private void Awake()
    {
        SetPlaceActive(true);
    }

    private void OnEnable()
    {
        Collider collider = GetComponent<BoxCollider>();

        var bounds = collider.bounds;

        var colliders = Physics.OverlapBox(bounds.center, bounds.extents);

        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].GetComponent<TowerSpawnBarrier>())
                SetPlaceActive(false);
        }
    }

    public void MakeActive()
    {
        SetPlaceActive(true);
    }

    private void SetPlaceActive(bool flag)
    {
        _active = flag;
        _model.SetActive(flag);
    }
}
