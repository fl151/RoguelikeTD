using UnityEngine;
using Agava.YandexGames;

public class Hider : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private void OnEnable()
    {
        Web.Instance.PlayerAuth += OnPlayerAuth;

        if (PlayerAccount.IsAuthorized)
        {
            _target.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Web.Instance.PlayerAuth += OnPlayerAuth;
    }

    private void OnPlayerAuth()
    {
        _target.gameObject.SetActive(false);
    }
}
