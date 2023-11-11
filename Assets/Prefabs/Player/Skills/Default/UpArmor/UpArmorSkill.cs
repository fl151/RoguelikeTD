public class UpArmorSkill : Skill
{
    private const float _armorBonus1 = 0.25f;
    private const float _armorBonus2 = 0.25f;
    private const float _armorBonus3 = 0.25f;

    private PlayerStats _player;

    protected override void UpgradeLevelOne()
    {
        _player = GetComponentInParent<PlayerStats>();

        _player.AddArmor(_armorBonus1);
    }

    protected override void UpgradeLevelTwo()
    {
        _player.AddArmor(_armorBonus2);
    }

    protected override void UpgradeLevelThree()
    {
        _player.AddArmor(_armorBonus3);

        base.UpgradeLevelThree();
    }
}
