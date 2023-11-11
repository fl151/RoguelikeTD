using UnityEngine;

public class WarriorBuffTowerBehavoir : MonoBehaviour
{
    [SerializeField] private float _damageBonus = 5;
    [SerializeField] private float _armorBonus = 0.01f;

    private PlayerStats _player;

    public void SetBonuses(float damage, float armor)
    {
        RemoveBonuses(_damageBonus, _armorBonus);

        _damageBonus = damage;
        _armorBonus = armor;

        AddBonuses(_damageBonus, _armorBonus);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerStats player))
        {
            if (player == _player) return;

            _player = player;

            AddBonuses(_damageBonus, _armorBonus);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerStats player))
        {
            RemoveBonuses(_damageBonus, _armorBonus);

            _player = null;
        }
    }

    private void RemoveBonuses(float damage, float armor)
    {
        if(_player != null)
        {
            _player.RemoveDamage(damage);
            _player.RemoveArmor(armor);
        }
    }

    private void AddBonuses(float damage, float armor)
    {
        if (_player != null)
        {
            _player.AddDamage(damage);
            _player.AddArmor(armor);
        }
    }
}
