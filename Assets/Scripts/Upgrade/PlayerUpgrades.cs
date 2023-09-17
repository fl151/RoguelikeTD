using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerUpgrades : MonoBehaviour
{
    [SerializeField] private PlayerCharecter _player;
    [SerializeField] private UpgradesConteiner _conteiner;

    private List<PlayerUpgrade> _validPlayerUpgrades = new List<PlayerUpgrade>();
    private List<Skill> _skills = new List<Skill>();

    public PlayerUpgrade[] ValidPlayerUpgrades => _validPlayerUpgrades.ToArray();

    private void OnEnable()
    {
        _player.CharecterSeted += OnCharecterSeted;
    }

    private void OnDisable()
    {
        _player.CharecterSeted -= OnCharecterSeted;

        foreach (var skill in _skills)
        {
            skill.MaxLevel -= RemoveUpgrade;
        }
    }

    public void UpLevelSkill(PlayerUpgrade upgrade)
    {
        var resultSkill = from Skill skill in _skills
                          where skill.Upgrade == upgrade
                          select skill;

        resultSkill.First().UpLevel();
    }

    private void OnCharecterSeted(Charecter charecter)
    {
        var upgradesChar = _conteiner.GetCharecterUpgrades(UpgradeBranch.Player, charecter);
        var upgradesDef = _conteiner.GetDefaultUpgrades(UpgradeBranch.Player);

        MergeArraysToList(upgradesChar, upgradesDef);

        InstantiateSkils();
    }

    private void MergeArraysToList(Upgrade[] array1, Upgrade[] array2)
    {
        if(array1 != null)
        {
            for (int i = 0; i < array1.Length; i++)
            {
                _validPlayerUpgrades.Add((PlayerUpgrade)array1[i]);
            }
        }

        if (array2 != null)
        {
            for (int i = 0; i < array2.Length; i++)
            {
                _validPlayerUpgrades.Add((PlayerUpgrade)array2[i]);
            }
        }
    }

    private void InstantiateSkils()
    {
        foreach (var playerUpgrade in _validPlayerUpgrades)
        {
            var skill = Instantiate(playerUpgrade.Skill, transform);
            skill.MaxLevel += RemoveUpgrade;
            _skills.Add(skill);
        }
    }

    private void RemoveUpgrade(PlayerUpgrade playerUpgrade)
    {
        if (_validPlayerUpgrades.Contains(playerUpgrade))
            _validPlayerUpgrades.Remove(playerUpgrade);
    }
}
