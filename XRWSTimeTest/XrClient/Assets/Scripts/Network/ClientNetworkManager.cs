using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ClientNetworkManager : NetworkManager
{
    public static ClientNetworkManager Instance { get; set; }

    //Паттерн singlateon
    //При загрузке сцены автоматически запускается клиент
    private void OnEnable()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        StartClient();
    }
}
