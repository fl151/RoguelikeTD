using UnityEngine;
using UnityEngine.Events;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected PlayerUpgrade _upgrade;

    protected int _currentLevel = 0;

    public Upgrade Upgrade => _upgrade;

    public event UnityAction<PlayerUpgrade> MaxLevel;

    public void UpLevel()
    {
        switch (_currentLevel)
        {
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

        Time.timeScale = 1;
    }

    protected abstract void UpgradeLevelOne();

    protected abstract void UpgradeLevelTwo();

    protected virtual void UpgradeLevelThree()
    {
        MaxLevel?.Invoke(_upgrade);
    }
}
