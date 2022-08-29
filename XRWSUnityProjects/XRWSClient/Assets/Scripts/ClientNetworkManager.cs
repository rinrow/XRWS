using Mirror;
using UnityEngine;

public class ClientNetworkManager : NetworkManager
{
    public static ClientNetworkManager Instance { get; set; }

    //Паттерн singlateon
    //При запуске приложения запускается клиент
    private void OnEnable()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);

        StartClient();
    }
}
