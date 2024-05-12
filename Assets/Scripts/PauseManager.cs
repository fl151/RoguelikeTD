using UnityEngine;
using UnityEngine.Events;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    public event UnityAction Paused;
    public event UnityAction Unpaused;

    public bool IsPaused => _isPaused;

    private bool _isPaused = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    public void Pause()
    {
        Paused?.Invoke();
        Time.timeScale = 0;

        _isPaused = true;
    }

    public void Unpause()
    {
        Unpaused?.Invoke();
        Time.timeScale = 1;

        _isPaused = false;
    }
}
