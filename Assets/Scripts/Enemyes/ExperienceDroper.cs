using UnityEngine;

public class ExperienceDroper : MonoBehaviour
{
    [SerializeField] private Experience _expPrefab;
    [Range(0, 1)]
    [SerializeField] private float _chanceDrop;

    private int _countLives = -1;

    private void OnDisable()
    {
        _countLives++;

        if (_chanceDrop != 0 && _countLives > 0)
            if (Random.Range(0f, 1f) <= _chanceDrop)
                Instantiate(_expPrefab, gameObject.transform.position, new Quaternion());
    }
}
