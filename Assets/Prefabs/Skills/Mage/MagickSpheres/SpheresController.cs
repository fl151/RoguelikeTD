using UnityEngine;

public class SpheresController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private MagickSphere _sphereTemlate;
    [SerializeField] private float _range = 10;
    [SerializeField] private int _countSpheres = 3;

    private MagickSphere[] _spheres;

    private void Update()
    {
        transform.Rotate(0, _rotateSpeed * Time.deltaTime, 0);
    }

    public void Init()
    {
        SpawnSpheres();
    }

    public void SetDamage(float value)
    {
        foreach (var sphere in _spheres)
        {
            sphere.SetDamage(value);
        }
    }

    public void SetEffect(int levelIndex)
    {
        foreach (var sphere in _spheres)
        {
            sphere.SetEffect(levelIndex);
        }
    }

    private void SpawnSpheres()
    {
        _spheres = new MagickSphere[_countSpheres];

        for (int i = 0; i < _countSpheres; i++)
        {
            Vector3 position = new Vector3(Mathf.Sin(360 / _countSpheres * Mathf.Deg2Rad * i) * _range,
                                           0, 
                                           Mathf.Cos(360 / _countSpheres * Mathf.Deg2Rad * i) * _range);

            _spheres[i] = Instantiate(_sphereTemlate, transform);
            _spheres[i].transform.position = transform.position + position;
        }
    }
}
