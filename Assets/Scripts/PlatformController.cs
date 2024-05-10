using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private GameObject _joystick;

    private void Awake()
    {
        if (Application.isMobilePlatform == false)
            _joystick.SetActive(false);
    }
}
