using Agava.YandexGames;
using UnityEngine;

public class GameReady : MonoBehaviour
{
    void Start()
    {
        YandexGamesSdk.GameReady();
    }
}
