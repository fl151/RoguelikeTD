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

    private void OnOpenCallback() {
        AudioListener.pause = true;
        AudioListener.volume = 0f;
    } // ��� ������� �������

    private void OnRewardedCallback() // ��� ������������� ������� �� �����
    {
        ContinueGame();
        
        _playerExp.AddLevel();
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
        AudioListener.pause = false;
        AudioListener.volume = 1f;

        _gameCanvas.SetActive(true);
        _myCanvas.SetActive(false);
    }
}
