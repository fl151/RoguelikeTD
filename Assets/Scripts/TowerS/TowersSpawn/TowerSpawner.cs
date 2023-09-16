using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private PlacesControler _placeController;

    private Tower _tower;
    private bool _isBuildingNow = false;

    public event UnityAction<Tower> Build;

    private void Update()
    {
        if(_isBuildingNow == false)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out TowerPlace towerPlace))
                {
                    if (towerPlace.Active)
                    {
                        var tower = Instantiate(_tower, hit.transform.position, hit.transform.rotation);

                        _isBuildingNow = false;
                        _placeController.gameObject.SetActive(false);

                        Time.timeScale = 1;

                        Build?.Invoke(tower);
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
