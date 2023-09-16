using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] private Upgrade _towerUpgrade;
    [SerializeField] private ParticleSystem _upgradeEffect;

    protected int _currentLevel = 0;

    private ParticleSystem _effect;

    public Upgrade TowerUpgrade => _towerUpgrade;

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

    protected abstract void UpgradeLevelOne();

    protected abstract void UpgradeLevelTwo();

    protected abstract void UpgradeLevelThree();

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
