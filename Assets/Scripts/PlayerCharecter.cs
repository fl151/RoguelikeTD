using UnityEngine;
using UnityEngine.Events;

public enum CharecterType
{
    Mage,
    Warrior,
    Summoner
}

public class PlayerCharecter : MonoBehaviour
{
    [SerializeField] private GameObject _mageModel;
    [SerializeField] private GameObject _warriorModel;
    [SerializeField] private GameObject _summonerModel;

    [SerializeField] private HeroRangeAttack _rangeAttack;
    [SerializeField] private HeroMeeleAttack _meeleAttack; 

    private CharecterType _charecter;

    public CharecterType Charecter => _charecter;

    public event UnityAction<CharecterType> CharecterSeted;

    public void SetCharecter(CharecterType charecter)
    {
        switch (charecter) {
            case CharecterType.Mage:
                SetMageCharecter();
                break;

            case CharecterType.Warrior:
                SetWarriorCharecter();
                break;

            case CharecterType.Summoner:
                SetSummonerCharecter();
                break;
        }

        _charecter = charecter;

        CharecterSeted?.Invoke(charecter);
    }

    private void SetMageCharecter()
    {
        var model = Instantiate(_mageModel, transform);

        _rangeAttack.enabled = true;

        SetAttackPoint(model);
    }

    private void SetWarriorCharecter()
    {
        var model = Instantiate(_warriorModel, transform);

        _meeleAttack.enabled = true;
    }

    private void SetSummonerCharecter()
    {
        var model = Instantiate(_summonerModel, transform);

        _rangeAttack.enabled = true;

        SetAttackPoint(model);
    }

    private void SetAttackPoint(GameObject model)
    {
        var attackPoint = model.GetComponentInChildren<AttackPoint>();

        _rangeAttack.SetAttackPoint(attackPoint.transform);
    }
}
