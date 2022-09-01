using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ServerNetworkManager : NetworkManager
{
    //При загрузке сцены автоматически запускается сервер
    private void OnEnable()
    {
        StartServer();
    }
}
