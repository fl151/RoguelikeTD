using UnityEngine;

public class LevelHolder : MonoBehaviour
{
    public static LevelHolder Instance;

    public Level Level { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetLevel(Level level)
    {
        Level = level;
    }
}
