using UnityEngine;

public enum Charecter
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
    

    private Charecter _charecter;

    public Charecter Charecter => _charecter;

    public void SetCharecter(Charecter charecter)
    {
        switch (charecter) {
            case Charecter.Mage:
                SetMageCharecter();
                break;

            case Charecter.Warrior:
                SetWarriorCharecter();
                break;

            case Charecter.Summoner:
                SetSummonerCharecter();
                break;
        }
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
