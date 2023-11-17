using UnityEngine;

public class CharecterHolder : MonoBehaviour
{
    public static CharecterHolder Instance;

    public CharecterType Charecter { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetCharecter(CharecterType charecter)
    {
        Charecter = charecter;
    }
}
