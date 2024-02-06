using Agava.WebUtility;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Events;

public class Web : MonoBehaviour
{
    public event UnityAction PlayerAuth;

    public static Web Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void Start()
    {
        //if(PlayerAccount.IsAuthorized == false)
        //    Progress.SetPrefsData();
        //else
        //    OnPlayerAuth();

        Progress.SetPrefsData();

        AuthAccount();
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    public static void AuthAccount()
    {
        if (PlayerAccount.IsAuthorized == false)
        {
            PlayerAccount.Authorize(Instance.OnPlayerAuth);
        }
        else
        {
            Instance.OnPlayerAuth();
        }
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        AudioListener.pause = inBackground;
        AudioListener.volume = inBackground ? 0f : 1f;

        Time.timeScale = inBackground ? 0f : 1f;
    }

    private void OnPlayerAuth()
    {
        PlayerAccount.RequestPersonalProfileDataPermission();

        PlayerAccount.GetCloudSaveData((data) => 
        { 
            Progress.SetDataFromJSON(data);
            PlayerAuth?.Invoke();
        });
    }
}
