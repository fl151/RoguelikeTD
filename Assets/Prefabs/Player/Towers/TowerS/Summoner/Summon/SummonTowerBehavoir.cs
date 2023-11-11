using System.Collections;
using UnityEngine;

public class SummonTowerBehavoir : MonoBehaviour
{
    [SerializeField] private float _spawnSpeed;
    [SerializeField] private Transform _spawnPoint;

    public void SetSpawnSpeed(float value)
    {
        _spawnSpeed = value;
    }

    private void Start()
    {
        StartCoroutine(SpanwCoroutine());
    }

    private IEnumerator SpanwCoroutine()
    {
        float coefDelayBefore = 0.2f;
        float coefDelayAfter = 0.8f;

        while (true)
        {
            float delay = 1 / _spawnSpeed;

            yield return new WaitForSeconds(coefDelayBefore * delay);

            SummonSkill.Instance.SpawnHelper(_spawnPoint.position);

            yield return new WaitForSeconds(coefDelayAfter * delay);
        }
    }
}
