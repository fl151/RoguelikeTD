using System.Collections;
using UnityEngine;

public class IceDebuff : MonoBehaviour
{
    private float _timeEffect = 2;

    [SerializeField] private float _slowCoeff;
    [SerializeField] private Material _iceMaterial;

    private SkinnedMeshRenderer _skin;
    private Enemy _movement;

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
        GetComponentInParent<EnemyHealth>().ColorController.AddEffect(new ColorEffect(Color.blue, _timeEffect, 3));

        _movement = transform.parent.GetComponent<Enemy>();
        _movement.MakeSlow(_slowCoeff);
    }

    private void FinishEffect()
    {
        _movement.MakeNormalSpeed();

        Destroy(gameObject);
    }
}
