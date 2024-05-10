using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private const int _layerMask = 1 << 6;

    [SerializeField] private float _rotateSpeed = 500f;
    [SerializeField] private Joystick _joystick;

    private NavMeshAgent _navMeshAgent;

    private bool _isRuning = false;

    private bool _isMobile = false;

    private Vector3 _lookDirection;

    public Vector3 LookDirection => _lookDirection;

    public bool IsRuning => _isRuning;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.angularSpeed = _rotateSpeed;

        _isMobile = Application.isMobilePlatform;
    }

    private void Update()
    {
        if (_isMobile == false && Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
                MoveTo(hit.point);
        }

        if (_isMobile)
        {
            Vector3 targetPoint = transform.position + new Vector3(_joystick.Direction.x,
                                                                   0, 
                                                                   _joystick.Direction.y);
            MoveTo(targetPoint);
        }

        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            _isRuning = false;
    }

    private void MoveTo(Vector3 targetPoint)
    {
        _navMeshAgent.SetDestination(targetPoint);
        _isRuning = true;

        RotateTowardsMouse(targetPoint);
    }

    private void RotateTowardsMouse(Vector3 point)
    {
        Vector3 targetPosition = point;
        targetPosition.y = transform.position.y;

        _lookDirection = targetPosition - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(_lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
    }
}
