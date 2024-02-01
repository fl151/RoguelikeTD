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

        VideoAd.Show(OnOpenCallback, OnRewardedCallback, OnCloseCallback, OnErrorCallback); // показ рекламы которую досматривать до конца лучше
    }

    private void OnOpenCallback() { } // при отрытии рекламы

    private void OnRewardedCallback() // при досматривании рекламы до конца
    {
        _playerExp.AddLevel();
        
        ContinueGame();
    }

    private void OnCloseCallback() // при закрыти не досматривая
    {
        ContinueGame();
    }

    private void OnErrorCallback(string error) // при ошибке
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
