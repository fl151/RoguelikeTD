using UnityEngine;

public class SetterBulletPool : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private void Start()
    {
        GetComponentInParent<HeroRangeAttack>().SetBulletPool(_pool);
    }
}
