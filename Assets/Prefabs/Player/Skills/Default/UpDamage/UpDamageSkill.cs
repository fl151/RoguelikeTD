public class UpDamageSkill : Skill
{
    private const float _damageBonus1 = 100;
    private const float _damageBonus2 = 100;
    private const float _damageBonus3 = 100;

    private PlayerStats _player;

    protected override void UpgradeLevelOne()
    {
        _player = GetComponentInParent<PlayerStats>();
        _player.AddDamage(_damageBonus1);
    }

    protected override void UpgradeLevelTwo()
    {
        _player.AddDamage(_damageBonus2);
    }

    protected override void UpgradeLevelThree()
    {
        _player.AddDamage(_damageBonus3);

        base.UpgradeLevelThree();
    }
}
