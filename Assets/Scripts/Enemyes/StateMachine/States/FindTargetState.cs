using UnityEngine;

public class FindTargetState : IState
{
    private Transform _enemyTransform;
    private float _agrRange;
    private Enemy _enemy;

    public FindTargetState(Enemy enemy)
    {
        _enemy = enemy;
        _enemyTransform = _enemy.transform;
        _agrRange = _enemy.AgrRange;
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

        var target = FindNearestTarget(hitColliders);

        if (target != null)
            _enemy.SetTarget(target.GetComponent<Health>());
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
