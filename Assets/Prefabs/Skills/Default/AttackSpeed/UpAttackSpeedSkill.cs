public class UpAttackSpeedSkill : Skill
{
    private const float _bonusAttackSpeed1 = 1;
    private const float _bonusAttackSpeed2 = 1;
    private const float _bonusAttackSpeed3 = 1;

    private PlayerStats _player;

    protected override void UpgradeLevelOne()
    {
        _player = GetComponentInParent<PlayerStats>();
        _player.AddAttackSpeed(_bonusAttackSpeed1);
    }

    protected override void UpgradeLevelTwo()
    {
        _player.AddAttackSpeed(_bonusAttackSpeed2);
    }

    protected override void UpgradeLevelThree()
    {
        _player.AddAttackSpeed(_bonusAttackSpeed3);

        base.UpgradeLevelThree();
    }
}
