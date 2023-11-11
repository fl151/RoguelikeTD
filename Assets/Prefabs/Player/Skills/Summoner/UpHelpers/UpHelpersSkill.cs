public class UpHelpersSkill : Skill
{
    private const float _damageBonus1 = 10;
    private const float _damageBonus2 = 10;
    private const float _damageBonus3 = 10;
    private const float _attackSpeedBonus1 = 0.25f;
    private const float _attackSpeedBonus2 = 0.25f;
    private const float _attackSpeedBonus3 = 0.25f;
    private const float _healthBonus1 = 25;
    private const float _healthBonus2 = 25;
    private const float _healthBonus3 = 25;

    private SummonSkill _summoner;

    protected override void UpgradeLevelOne()
    {
        _summoner = transform.parent.GetComponentInChildren<SummonSkill>();

        _summoner.AddStats(_damageBonus1, _attackSpeedBonus1, _healthBonus1); 
    }

    protected override void UpgradeLevelTwo()
    {
        _summoner.AddStats(_damageBonus2, _attackSpeedBonus2, _healthBonus2);
    }

    protected override void UpgradeLevelThree()
    {
        _summoner.AddStats(_damageBonus3, _attackSpeedBonus3, _healthBonus3);

        base.UpgradeLevelThree();
    }
}
