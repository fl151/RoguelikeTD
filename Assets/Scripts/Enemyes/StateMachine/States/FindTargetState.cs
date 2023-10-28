using UnityEngine;

public class FindTargetState : IState
{
    private Transform _enemyTransform;
    private float _agrRange;
    private Enemy _enemy;

    public FindTargetState(Transform enemyTransform, float agrRange, Enemy enemy)
    {
        _enemyTransform = enemyTransform;
        _agrRange = agrRange;
    }

    public void Start(){}

    public void OnTick()
    {
        FindNewTarget();
    }

    public void Stop(){}

    private void FindNewTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_enemyTransform.position, _agrRange);

        var enemyGameObject = FindNearestTarget(hitColliders);

        if (enemyGameObject != null)
            _enemy.SetTarget(enemyGameObject.GetComponent<Health>());
    }

    private GameObject FindNearestTarget(Collider[] colliders)
    {
        GameObject nearestTarget = null;
        float nearestDistance = float.MaxValue;

        foreach (Collider collider in colliders)
        {
            Health target = collider.GetComponent<Health>();

            if (target != null && collider.gameObject.activeSelf)
            {
                float distance = Vector3.Distance(_enemyTransform.position, collider.transform.position);

                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestTarget = collider.gameObject;
                }
            }
        }

        return nearestTarget;
    }
}
