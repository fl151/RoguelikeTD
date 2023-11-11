public class UpAttackRangeSkill : Skill
{
    private const float _attackRangeCoef1 = 1.5f;
    private const float _attackRangeCoef2 = 1.75f;
    private const float _attackRangeCoef3 = 2f;

    private HeroMeeleAttack _heroAttack;

    protected override void UpgradeLevelOne()
    {
        _heroAttack = GetComponentInParent<HeroMeeleAttack>();

        _heroAttack.SetAttackRangeCoefficient(_attackRangeCoef1);
    }

    protected override void UpgradeLevelTwo()
    {
        _heroAttack.SetAttackRangeCoefficient(_attackRangeCoef2);
    }

    protected override void UpgradeLevelThree()
    {
        _heroAttack.SetAttackRangeCoefficient(_attackRangeCoef3);

        base.UpgradeLevelThree();
    }
}
