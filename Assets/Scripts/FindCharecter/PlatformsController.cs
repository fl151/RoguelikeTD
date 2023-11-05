using System.Collections.Generic;
using UnityEngine;

public class PlatformsController : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private List<GameObject> _charecterPrefabs;
    [SerializeField] private float _range;

    private List<GameObject> _variants;
    private int _countVariants;

    private void Awake()
    {
        _countVariants = _charecterPrefabs.Count;
    }

    private void Start()
    {
        SpawnVariants();
    } 

    private void SpawnVariants()
    {
        _variants = new List<GameObject>();

        for (int i = 0; i < _countVariants; i++)
        {
            var position = new Vector3(Mathf.Sin(360 / _countVariants * Mathf.Deg2Rad * i) * _range,
                                           0,
                                           Mathf.Cos(360 / _countVariants * Mathf.Deg2Rad * i) * _range);

            SpanwVariant(position, i);
        }
    }

    private void SpanwVariant(Vector3 position, int chrecterIndex)
    {
        var variant = Instantiate(_platformPrefab, transform);

        variant.transform.position = transform.position + position;

        Vector3 targetDir = transform.position - variant.transform.position;
        variant.transform.rotation = Quaternion.LookRotation(targetDir);

        _variants.Add(variant);

        SpawnCharecter(variant.transform, _charecterPrefabs[chrecterIndex]);
    }

    private void SpawnCharecter(Transform parent, GameObject prefab)
    {
        Instantiate(prefab, parent);
    }
}
