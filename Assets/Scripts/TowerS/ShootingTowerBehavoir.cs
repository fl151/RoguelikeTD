using UnityEngine;

public abstract class ShootingTowerBehavoir : MonoBehaviour
{
    protected GameObject _target;

    public GameObject GetTarget()
    {
        return _target;
    }
}
