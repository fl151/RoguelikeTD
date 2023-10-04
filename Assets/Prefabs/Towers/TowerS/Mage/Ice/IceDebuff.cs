using System.Collections;
using UnityEngine;

public class IceDebuff : MonoBehaviour
{
    private float _timeEffect = 2;

    [SerializeField] private float _slowCoeff;
    [SerializeField] private Material _iceMaterial;

    private Material _oldMaterial;
    private SkinnedMeshRenderer _skin;
    private EnemyMovement _movement;

    private void Start()
    {
        StartCoroutine(PlayEffect());
    }

    public void SetSlowCoefficient(float value)
    {
        _slowCoeff = value;
    }

    public void Finish()
    {
        FinishEffect();
    }

    private IEnumerator PlayEffect()
    {
        StartEffect();

        yield return new WaitForSeconds(_timeEffect);

        FinishEffect();   
    }

    private void StartEffect()
    {
        _skin = transform.parent.GetComponentInChildren<SkinnedMeshRenderer>();

        _oldMaterial = _skin.material;
        _skin.material = _iceMaterial;

        _movement = transform.parent.GetComponent<EnemyMovement>();
        _movement.MakeSlow(_slowCoeff);
    }

    private void FinishEffect()
    {
        _skin.material = _oldMaterial;
        _movement.MakeNormalSpeed();

        Destroy(gameObject);
    }
}
