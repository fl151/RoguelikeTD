using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FindLevelButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(FindLevel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(FindLevel);
    }

    private void FindLevel()
    {
        FindLevelController.Instance.FindLevel();
    }
}
