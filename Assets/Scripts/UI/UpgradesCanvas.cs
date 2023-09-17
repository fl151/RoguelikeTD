using UnityEngine;

[RequireComponent(typeof(Canvas), typeof(UpgradesConteiner))]
public class UpgradesCanvas : MonoBehaviour
{
    private const int _countVariantsUpgrades = 3;

    [SerializeField] private Transform _panelParent;
    [SerializeField] private UpgradeView _buttonUpgradePrefab;
    [SerializeField] private PlayerTowers _playerTowers;

    private UpgradesConteiner _conteiner;
    private PlayerCharecter _playerCharecter;
    private PlayerUpgrades _playerUpgrades;

    private UpgradeView[] _currentViews;

    private Charecter _charecter;

    private void Awake()
    {
        _conteiner = GetComponent<UpgradesConteiner>();
        _playerCharecter = _playerTowers.GetComponent<PlayerCharecter>();
        _playerUpgrades = _playerTowers.GetComponent<PlayerUpgrades>();
        _currentViews = new UpgradeView[_countVariantsUpgrades];
    }

    private void OnEnable()
    {
        _playerCharecter.CharecterSeted += SetCharecter;
    }

    private void OnDisable()
    {
        _playerCharecter.CharecterSeted -= SetCharecter;
    }

    public void Fill(UpgradeBranch branch)
    {
        DestroyOldViews();

        var playerUpgrades = _playerUpgrades.ValidPlayerUpgrades;
        var towersUpgrades = _playerTowers.GetUpgrades();

        var upgrades = GetMergetArray(playerUpgrades, towersUpgrades);

        for (int i = 0; i < _countVariantsUpgrades; i++)
        {
            var view =  Instantiate(_buttonUpgradePrefab, _panelParent);
            view.Fill(GetRandomUpgrade(upgrades));

            _currentViews[i] = view;
        }
    }

    private Upgrade GetRandomUpgrade(Upgrade[] upgradeVariants)
    {
        if (upgradeVariants.Length == 0) return null;

        int index = Random.Range(0, upgradeVariants.Length);

        return upgradeVariants[index];
    }

    private Upgrade[] GetMergetArray(Upgrade[] array1, Upgrade[] array2)
    {
        Upgrade[] result = new Upgrade[array1.Length + array2.Length];

        for (int i = 0; i < array1.Length; i++)
        {
            result[i] = array1[i];
        }

        for (int i = 0; i < array2.Length; i++)
        {
            result[array1.Length + i] = array2[i];
        }

        return result;
    }

    private void DestroyOldViews()
    {
        for (int i = 0; i < _currentViews.Length; i++)
            if (_currentViews[i] != null)
                Destroy(_currentViews[i].gameObject);
    }

    private void SetCharecter(Charecter charecter)
    {
        _charecter = charecter;
    }
}
