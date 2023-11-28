using UnityEngine;

public class LevelsView : MonoBehaviour
{
    [SerializeField] private Transform _panelConteiner;
    [SerializeField] private LevelInfoView _prefabLevelView;

    private void OnEnable()
    {
        LevelsController.Instance.LevelUpgrade += OnLevelUpgrade;
    }

    private void Start()
    {
        FillView();
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
        var old = _panelConteiner.GetComponentsInChildren<LevelInfoView>();

        foreach (var item in old)
        {
            Destroy(item.gameObject);
        }

        var levels = LevelsController.Instance.GetLevels();

        foreach (var levelPair in levels)
        {
            LevelInfoView levelInfo = Instantiate(_prefabLevelView, _panelConteiner);

            levelInfo.Fill(levelPair);
        }
    }
}
