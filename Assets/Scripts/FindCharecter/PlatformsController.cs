using System.Collections.Generic;
using UnityEngine;

public class PlatformsController : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private List<Charecter> _charecterPrefabs;
    [SerializeField] private float _range;

    private List<GameObject> _platforms;
    private int _countVariants;
    private VariantNode _currentNode;

    private void Awake()
    {
        _countVariants = _charecterPrefabs.Count;
    }

    private void Start()
    {
        SpawnVariants();
        _currentNode = CreateVariantsNodes();
    }

    private void SpawnVariants()
    {
        _platforms = new List<GameObject>();

        for (int i = 0; i < _countVariants; i++)
        {
            var position = new Vector3(Mathf.Sin(360 / _countVariants * Mathf.Deg2Rad * (_countVariants - i)) * _range,
                                           0,
                                           Mathf.Cos(360 / _countVariants * Mathf.Deg2Rad * (_countVariants - i)) * _range);

            SpanwVariant(position, i);
        }
    }

    private void SpanwVariant(Vector3 position, int chrecterIndex)
    {
        var platform = Instantiate(_platformPrefab, transform);

        platform.transform.position = transform.position + position;

        Vector3 targetDir = transform.position - platform.transform.position;
        platform.transform.rotation = Quaternion.LookRotation(targetDir);

        _platforms.Add(platform);

        SpawnCharecter(platform.transform, _charecterPrefabs[chrecterIndex].gameObject);
    }

    private void SpawnCharecter(Transform parent, GameObject prefab)
    {
        Instantiate(prefab, parent);
    }

    private VariantNode CreateVariantsNodes()
    {
        if (_platforms.Count == 0) return null;
        if (_platforms.Count == 1) return new VariantNode(_platforms[0]);

        List<VariantNode> nodes = new List<VariantNode>();

        foreach (var platform in _platforms)
        {
            nodes.Add(new VariantNode(platform));
        }

        nodes[0].Init(nodes[^1], nodes[1]);
        nodes[^1].Init(nodes[^2], nodes[0]);

        for (int i = 1; i < nodes.Count - 1; i++)
        {
            nodes[i].Init(nodes[i - 1], nodes[i + 1]);
        }

        return nodes[0];
    }

    private void SwipeToLeft()
    {

    }

    private void SwipeToRight()
    {

    }

    private void MakeReadyRight(Transform transform)
    {

    }

    private void MakeReadyLeft(Transform transform)
    {

    }
}
