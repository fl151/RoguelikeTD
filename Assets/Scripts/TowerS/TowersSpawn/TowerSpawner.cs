using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private PlacesControler _placeController;

    private Tower _tower;
    private bool _isBuildNow = false;

    private void Update()
    {
        if(_isBuildNow == false)
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
                        Instantiate(_tower, hit.transform.position, hit.transform.rotation);

                        _isBuildNow = false;
                        _placeController.gameObject.SetActive(false);

                        Time.timeScale = 1;
                    }
                }
            }
        }
    }

    public void Build(Tower tower)
    {
        _tower = tower;
        _placeController.gameObject.SetActive(true);
        _isBuildNow = true;
    }
}
