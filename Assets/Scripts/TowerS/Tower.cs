using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] private Upgrade _towerUpgrade;
    [SerializeField] private ParticleSystem _upgradeEffect;

    [SerializeField] protected int _currentLevel = 0;

    private ParticleSystem _effect;

    public event UnityAction<Upgrade> MaxLevel;

    public Upgrade TowerUpgrade => _towerUpgrade;
    public int CurrentLevel => _currentLevel;

    private void Awake()
    {
        _effect = Instantiate(_upgradeEffect, transform);
        _effect.Stop();
    }

    public void UpdateTower()
    {
        switch (_currentLevel) {

            case 0:
                UpgradeLevelOne();
                break;

            case 1:
                UpgradeLevelTwo();
                break;

            case 2:
                UpgradeLevelThree();
                break;

            default:
                return;
        }

        _currentLevel++;
        PlayEffect();

        Time.timeScale = 1;
    }

    public void UpLevel(int level)
    {
        int levelRange = level - _currentLevel;

        for (int i = 0; i < levelRange; i++)
        {
            UpdateTower();
        }
    }

    protected abstract void UpgradeLevelOne();

    protected abstract void UpgradeLevelTwo();

    protected virtual void UpgradeLevelThree()
    {
        MaxLevel?.Invoke(_towerUpgrade);
    }

    private void PlayEffect()
    {
        StartCoroutine(PlayEffectCoroutine(_effect));
    }

    private IEnumerator PlayEffectCoroutine(ParticleSystem effect)
    {
        _effect.Play();

        yield return new WaitForSeconds(0.75f);

        _effect.Stop();
    }
}
