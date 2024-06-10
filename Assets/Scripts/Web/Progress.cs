using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Events;

public enum Language1
{
    Null,
    Ru,
    En,
    Tr
}

public class PlayerData
{
    public int CountLevelsOpened = 1;

    public Language1 Language = Language1.Null;
}

public class Progress : MonoBehaviour
{
    private const string _dataPrefsName = "data";

    public PlayerData PlayerData;

    public static Progress Instance;

    public event UnityAction DataLoaded;
    public event UnityAction<PlayerData> NeedAsk;

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

    public static void SaveDataCloud()
    {
        string json = JsonUtility.ToJson(Instance.PlayerData);

        if (PlayerAccount.IsAuthorized)
            PlayerAccount.SetCloudSaveData(json);

        PlayerPrefs.SetString(_dataPrefsName, json);
        PlayerPrefs.Save();
    }

    public static void SetDataFromJSON(string json)
    {
        var dataCloud = JsonUtility.FromJson<PlayerData>(json);
        var dataPrefs = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString(_dataPrefsName));

        if (AreDatasEquals(dataCloud, dataPrefs))
            SetData(dataPrefs);
        else if (dataPrefs == default)
            SetData(dataCloud);
        else
            SetData(dataCloud);
    }

    public static void SetPrefsData()
    {
        PlayerData dataPrefs = new PlayerData();

        if (PlayerPrefs.HasKey(_dataPrefsName))
            dataPrefs = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString(_dataPrefsName));

        SetData(dataPrefs);
    }

    public static void SetData(PlayerData data)
    {
        Instance.PlayerData = data;
        Instance.DataLoaded?.Invoke();

        Debug.Log("data loaded");
    }

    private static void AskUserAboutProgress(PlayerData dataCloud)
    {
        Instance.NeedAsk?.Invoke(dataCloud);
    }

    private static bool AreDatasEquals(PlayerData data1, PlayerData data2)
    {
        if (data1.CountLevelsOpened != data2.CountLevelsOpened)
            return false;

        if (data1.Language != data2.Language)
            return false;

        return true;
    }
}
