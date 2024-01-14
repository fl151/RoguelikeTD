using UnityEngine;
using UnityEngine.Events;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    public event UnityAction Paused;
    public event UnityAction Unpaused;

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
    }

    public void Unpause()
    {
        Unpaused?.Invoke();
        Time.timeScale = 1;
    }
}
