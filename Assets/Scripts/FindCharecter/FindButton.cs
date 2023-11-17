using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FindButton : MonoBehaviour
{
    [SerializeField] private PlatformsController _platformsController;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        CharecterHolder.Instance.SetCharecter(_platformsController.CurrentCharecter);

        SceneManager.LoadScene(1);
    }
}
