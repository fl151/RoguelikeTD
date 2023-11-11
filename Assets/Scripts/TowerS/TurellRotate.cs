using UnityEngine;

[RequireComponent(typeof(ShootingTowerBehavoir))]
public class TurellRotate : MonoBehaviour
{
    [SerializeField] private Transform _turrel;
    [SerializeField] private float _rotationSpeed;

    private ShootingTowerBehavoir _tower;

    private void Awake()
    {
        _tower = GetComponent<ShootingTowerBehavoir>();
    }

    private void Update()
    {
        RotateTowardsTarget();           
    }

    private void RotateTowardsTarget()
    {
        var target = _tower.GetTarget();

        if(target != null)
        {
            Vector3 targetDirection = target.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            _turrel.rotation = Quaternion.RotateTowards(_turrel.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}