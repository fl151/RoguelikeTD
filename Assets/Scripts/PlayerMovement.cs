using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private const int _layerMask = 1 << 6;

    [SerializeField] private float _rotateSpeed = 500f;

    private NavMeshAgent _navMeshAgent;

    private bool _isRuning = false;

    public bool IsRuning => _isRuning;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.angularSpeed = _rotateSpeed;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
            {
                _navMeshAgent.SetDestination(hit.point);
                _isRuning = true;

                RotateTowardsMouse(hit);
            }
        }

        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _isRuning = false;
        }
    }

    private void RotateTowardsMouse(RaycastHit hit)
    {
        Vector3 targetPosition = hit.point;
        targetPosition.y = transform.position.y;

        Vector3 lookDirection = targetPosition - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
    }
}
