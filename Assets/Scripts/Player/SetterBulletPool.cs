using UnityEngine;

public class SetterBulletPool : MonoBehaviour
{
    [SerializeField] private TargetBullet _prefab;
    [SerializeField] private int _count;

    private ObjectPool<TargetBullet> _pool;

    private void Start()
    {
        _pool = new ObjectPool<TargetBullet>(_prefab, _count, true);

        GetComponentInParent<HeroRangeAttack>().SetBulletPool(_pool);
    }
}
