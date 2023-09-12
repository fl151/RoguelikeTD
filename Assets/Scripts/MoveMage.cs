using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class MoveMage : MonoBehaviour
{    
    [SerializeField] private float _rotateSpeed = 500f;
    private NavMeshAgent _navMeshAgent;

    private Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.angularSpeed = _rotateSpeed;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _navMeshAgent.SetDestination(hit.point);
                _animator.SetBool(Animator.StringToHash("isRun"), true);
            }

            RotateTowardsMouse();
        }

        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _animator.SetBool(Animator.StringToHash("isRun"), false);
        }        
    }

    private void RotateTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = transform.position.y;

            Vector3 lookDirection = targetPosition - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
                
        }
    }
}