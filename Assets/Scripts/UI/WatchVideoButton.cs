using Agava.YandexGames;
using UnityEngine;

public class WatchVideoButton : DefaultButton
{
    [SerializeField] private GameObject _myCanvas;
    [SerializeField] private GameObject _gameCanvas;
    [Space]
    [SerializeField] private PlayerExperience _playerExp;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        VideoAd.Show(OnOpenCallback, OnRewardedCallback, OnCloseCallback, OnErrorCallback); // ����� ������� ������� ������������ �� ����� �����
    }

    private void OnOpenCallback() { } // ��� ������� �������

    private void OnRewardedCallback() // ��� ������������� ������� �� �����
    {
        _playerExp.AddLevel();
        
        ContinueGame();
    }

    private void OnCloseCallback() // ��� ������� �� �����������
    {
        ContinueGame();
    }

    private void OnErrorCallback(string error) // ��� ������
    {
        ContinueGame();
    }

    private void ContinueGame()
    {
        PauseManager.Instance.Unpause();

        _gameCanvas.SetActive(true);
        _myCanvas.SetActive(false);
    }
}
