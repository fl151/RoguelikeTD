using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ExperienceView : MonoBehaviour
{
    [SerializeField] private PlayerExperience _player;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.ExpGained += UpdateView;
    }

    private void Start()
    {
        UpdateView();
    }

    private void OnDisable()
    {
        _player.ExpGained -= UpdateView;
    }

    private void UpdateView()
    {
        _slider.value = _player.ShareOfNextLevel;
    }
}
