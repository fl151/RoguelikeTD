using UnityEngine;

[RequireComponent(typeof(Folower))]
public class Reloader : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    private bool _isActive = true;
    private Folower _folower;


    private void Awake()
    {
        _folower = GetComponent<Folower>();
    }

    private void Update()
    {
        if(_isActive == false && _folower.IsTargetActive == true)
        {
            _object.SetActive(false);
            _object.SetActive(true);
        }

        _isActive = _folower.IsTargetActive;
    }
}
