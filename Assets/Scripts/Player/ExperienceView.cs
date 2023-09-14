using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ExperienceView : MonoBehaviour
{
    [SerializeField] private PlayerExperience _player;
    [SerializeField] private TMP_Text _levelText;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.ExpGained += UpdateView;
        _player.LevelUp += UpdateLevel;
    }

    private void Start()
    {
        UpdateView();
        UpdateLevel();
    }

    private void OnDisable()
    {
        _player.ExpGained -= UpdateView;
        _player.LevelUp -= UpdateLevel;
    }

    private void UpdateView()
    {
        _slider.value = _player.ShareOfNextLevel;
    }

    private void UpdateLevel()
    {
        _levelText.text = _player.CurrentLevel.ToString();
    }
}
