using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ServerNetworkManager : NetworkManager
{
    //��� �������� ����� ������������� ����������� ������
    private void OnEnable()
    {
        StartServer();
    }
}
