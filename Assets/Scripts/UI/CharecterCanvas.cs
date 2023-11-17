using UnityEngine;

public class CharecterCanvas : MonoBehaviour
{
    [SerializeField] private PlayerCharecter _player;

    private void Start()
    {
        if (CharecterHolder.Instance == null)
            Time.timeScale = 0;
    }

    public void SetCharecter(CharecterType charecter)
    {
        _player.SetCharecter(charecter);

        Time.timeScale = 1;

        gameObject.SetActive(false);
    }
}
