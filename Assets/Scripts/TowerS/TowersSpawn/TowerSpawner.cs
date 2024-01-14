using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerTowers))]
public class TowerSpawner : MonoBehaviour
{
    private const int _layerMask = 1 << 3;

    [SerializeField] private PlacesControler _placeController;

    private Tower _tower;
    private bool _isBuildingNow = false;

    private PlayerTowers _playerTowers;

    public event UnityAction<Tower> Build;

    private void Awake()
    {
        _playerTowers = GetComponent<PlayerTowers>();
    }

    private void Update()
    {
        if (_isBuildingNow == false)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
            {
                if (hit.collider.gameObject.TryGetComponent(out TowerPlace towerPlace))
                {
                    if (towerPlace.Active)
                    {
                        var tower = Instantiate(_tower, hit.transform.position, hit.transform.rotation);

                        _isBuildingNow = false;
                        _placeController.gameObject.SetActive(false);

                        PauseManager.Instance.Unpause();

                        Build?.Invoke(tower);

                        int level = _playerTowers.GetCurrentTowerLevel(tower);

                        tower.UpLevel(level);
                    }
                }
            }
        }
    }

    public void StartBuild(Tower tower)
    {
        _tower = tower;
        _placeController.gameObject.SetActive(true);
        _isBuildingNow = true;
    }
}
