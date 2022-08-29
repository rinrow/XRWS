using Mirror;
using UnityEngine;

public class ServerNetworkManager : NetworkManager
{
    //ѕри запуске приложени€ стартует сервер
    private void OnEnable()
    {
        StartServer();
    }
}
