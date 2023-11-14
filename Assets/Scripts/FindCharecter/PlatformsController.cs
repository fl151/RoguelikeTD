using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformsController : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private List<Charecter> _charecterPrefabs;
    [SerializeField] private float _range;
    [SerializeField] private SwipeController _swipeController;

    private int _countVariants;
    private VariantNode _currentNode;

    public event UnityAction SwipeFinished;

    private void Awake()
    {
        _countVariants = _charecterPrefabs.Count;
    }

    private void OnEnable()
    {
        _swipeController.OnSwipe += OnSwipe;
    }

    private void Start()
    {
        var platforms = SpawnVariants();
        _currentNode = CreateVariantsNodes(platforms);
    }

    private void OnDisable()
    {
        _swipeController.OnSwipe -= OnSwipe;
    }

    private List<GameObject> SpawnVariants()
    {
         var platforms = new List<GameObject>();

        if(_countVariants > 0)
        {
            var positionFirst = GetPositionOnDegrees(0);

            SpanwVariant(platforms, positionFirst, 0);
        }

        for (int i = 1; i < _countVariants; i++)
        {
            var position = GetPositionOnDegrees(180);

            SpanwVariant(platforms, position, i);
        }

        return platforms;
    }

    private Vector3 GetPositionOnDegrees(float degrees)
    {
        var position = new Vector3(Mathf.Sin(degrees * Mathf.Deg2Rad) * _range,
                                           0,
                                           Mathf.Cos(degrees * Mathf.Deg2Rad) * _range);

        return position;
    }

    private void SpanwVariant(List<GameObject> platforms, Vector3 position, int chrecterIndex)
    {
        var platform = Instantiate(_platformPrefab, transform);

        platform.transform.position = transform.position + position;

        Vector3 targetDir = transform.position - platform.transform.position;
        platform.transform.rotation = Quaternion.LookRotation(targetDir);

        platforms.Add(platform);

        SpawnCharecter(platform.transform, _charecterPrefabs[chrecterIndex].gameObject);
    }

    private void SpawnCharecter(Transform parent, GameObject prefab)
    {
        Instantiate(prefab, parent);
    }

    private VariantNode CreateVariantsNodes(List<GameObject> platforms)
    {
        if (platforms.Count == 0) return null;
        if (platforms.Count == 1) return new VariantNode(platforms[0]);

        List<VariantNode> nodes = new List<VariantNode>();

        foreach (var platform in platforms)
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

    private void OnSwipe(Swipe swipe)
    {

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
