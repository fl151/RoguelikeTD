using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIer : MonoBehaviour
{
    private float _lifeTime = 15;

    private Coroutine _lifeCoroutine;

    private void OnEnable()
    {
        _lifeCoroutine = StartCoroutine(Life());
    }

    private void OnDisable()
    {
        StopCoroutine(_lifeCoroutine);
    }

    private IEnumerator Life()
    {
        yield return new WaitForSeconds(_lifeTime);

        gameObject.SetActive(false);
    }
}
