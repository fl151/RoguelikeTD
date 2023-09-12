using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    private void Update()
    {
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
                    }
                }
            }
        }
    }
}
