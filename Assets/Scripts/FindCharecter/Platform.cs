using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform _towerTransform1;
    [SerializeField] private Transform _towerTransform2;

    public Transform TowerTransform1 => _towerTransform1;
    public Transform TowerTransform2 => _towerTransform2;
}
