using UnityEngine;

public class LevelsView : MonoBehaviour
{
    [SerializeField] private Transform _panelConteiner;
    [SerializeField] private LevelInfoView _prefabLevelView;

    private void OnEnable()
    {
        LevelsController.Instance.LevelUpgrade += OnLevelUpgrade;
    }

    private void OnDisable()
    {
        LevelsController.Instance.LevelUpgrade -= OnLevelUpgrade;
    }

    private void OnLevelUpgrade()
    {
        FillView();
    }

    private void FillView()
    {

    }
}
