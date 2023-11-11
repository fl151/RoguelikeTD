using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerUpgrade : Upgrade
{
    [SerializeField] protected Skill _skillPrefab;

    public Skill Skill => _skillPrefab;
}
