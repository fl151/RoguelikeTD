using UnityEngine;

public class FindTargetHelperState : IState
{
    private Transform _helperTransform;
    private float _agrRange;
    private Helper _helper;

    public FindTargetHelperState(Helper helper)
    {
        _helper = helper;
        _helperTransform = _helper.transform;
        _agrRange = _helper.AgrRange;
    }

    public void Start() { }

    public void OnTick()
    {
        FindNewTarget();
    }

    public void Stop() { }

    private void FindNewTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_helperTransform.position, _agrRange);

        var target = FindNearestTarget(hitColliders);

        if (target != null)
            _helper.SetTarget(target.GetComponent<EnemyHealth>());
    }

    private GameObject FindNearestTarget(Collider[] colliders)
    {
        GameObject nearestTarget = null;
        float nearestDistance = float.MaxValue;

        for(var i = 0; i < colliders.Length; i++)
        {
            var collider = colliders[i];

            EnemyHealth target = collider.GetComponent<EnemyHealth>();

            if (target != null && collider.gameObject.activeSelf)
            {
                float distance = Vector3.Distance(_helperTransform.position, collider.transform.position);

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
