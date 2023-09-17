using UnityEngine;

public class CharecterCanvas : MonoBehaviour
{
    [SerializeField] private PlayerCharecter _player;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void SetCharecter(Charecter charecter)
    {
        _player.SetCharecter(charecter);

        Time.timeScale = 1;

        gameObject.SetActive(false);
    }
}
